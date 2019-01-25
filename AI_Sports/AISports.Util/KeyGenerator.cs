using AI_Sports.Dao;
using AI_Sports.Entity;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Sports.Util
{
    public class KeyGenerator
    {
        private static object myLock = new object();
        private static ConcurrentDictionary<string, KeyEntity> cache = new ConcurrentDictionary<string, KeyEntity>();

        private static int defaultKeyCount = 100;

        public static long GetNextKeyValueLong(String keyID)
        {
           KeyDAO keyDAO = new KeyDAO();
            KeyEntity keyEntity = null;
            cache.TryGetValue(keyID, out keyEntity);
            long keyValue = 0;
            if (keyEntity == null)
            {//双重检查防止并发
                lock (myLock)
                {
                    cache.TryGetValue(keyID, out keyEntity);
                    if (keyEntity == null)
                    {
                        keyEntity = keyDAO.Load(keyID);
                        if (keyEntity == null)
                        {
                            keyEntity = new KeyEntity
                            {
                                Steps = defaultKeyCount,
                                Key_id = keyID,
                                Max_value = defaultKeyCount,
                                LastValue = 0
                            };
                            keyDAO.Insert(keyEntity);
                           
                        }
                        else
                        {
                             
                            keyDAO.UpdateMaxValue(keyID, keyEntity.Steps);
                            keyEntity.LastValue = keyEntity.Max_value;
                            keyEntity.Max_value += keyEntity.Steps;
                        }
                        cache[keyID] = keyEntity;
                    }

                }
            }

            lock (keyEntity)
            {
                keyValue = keyEntity.GetNextValue();
                if (keyValue == 0)
                {
                    //缓存里的值已经用完，再次申请
                    keyDAO.UpdateMaxValue(keyID, keyEntity.Steps);
                    keyEntity.LastValue = keyEntity.Max_value;
                    keyEntity.Max_value += keyEntity.Steps;
                }
            }

            return keyValue;
        }
    }
}
