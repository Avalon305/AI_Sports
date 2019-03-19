﻿//*********************************************************
//
// Copyright (c) Microsoft. All rights reserved.
// THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
// IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
// PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
//
//*********************************************************

#include "pch.h"
#include "MainPage.xaml.h"
#include "SampleConfiguration.h"
#include "BackgroundActivity.h"

using namespace SDKTemplate;
using namespace Windows::ApplicationModel;
using namespace Windows::ApplicationModel::Activation;
using namespace Windows::Foundation;
using namespace Windows::Foundation::Collections;

String^ BackgroundTaskSample::SampleBackgroundTaskProgress = "";
bool BackgroundTaskSample::SampleBackgroundTaskRegistered = false;

String^ BackgroundTaskSample::SampleBackgroundTaskWithConditionProgress = "";
bool BackgroundTaskSample::SampleBackgroundTaskWithConditionRegistered = false;

String^ BackgroundTaskSample::ServicingCompleteTaskProgress = "";
bool BackgroundTaskSample::ServicingCompleteTaskRegistered = false;

String^ BackgroundTaskSample::TimeTriggeredTaskProgress = "";
bool BackgroundTaskSample::TimeTriggeredTaskRegistered = false;

String^ BackgroundTaskSample::ApplicationTriggerTaskProgress = "";
bool BackgroundTaskSample::ApplicationTriggerTaskRegistered = false;
String^ BackgroundTaskSample::ApplicationTriggerTaskResult = "";

String^ BackgroundTaskSample::GroupedBackgroundTaskProgress = "";
bool BackgroundTaskSample::GroupedBackgroundTaskRegistered = false;


PropertySet^ BackgroundTaskSample::TaskStatuses = ref new PropertySet();

Array<Scenario>^ MainPage::scenariosInner = ref new Array<Scenario>
{
    // The format here is the following:
    //     { "Description for the sample", "Fully quaified name for the class that implements the scenario" }
    { "Background task", "SDKTemplate.SampleBackgroundTask" },
    { "Background task with a condition", "SDKTemplate.SampleBackgroundTaskWithCondition" },
    { "Servicing complete task", "SDKTemplate.ServicingCompleteTask" },
    { "Background task with time trigger", "SDKTemplate.TimeTriggeredTask" },
    { "Background task with application trigger", "SDKTemplate.ApplicationTriggerTask" },
    { "Grouped background task", "SDKTemplate.GroupedBackgroundTask" },
};

String^ BackgroundTaskSample::GetBackgroundTaskStatus(String^ name)
{
    auto registered = false;
    if (name == SampleBackgroundTaskName)
    {
        registered = BackgroundTaskSample::SampleBackgroundTaskRegistered;
    }
    else if (name == SampleBackgroundTaskWithConditionName)
    {
        registered = BackgroundTaskSample::SampleBackgroundTaskWithConditionRegistered;
    }
    else if (name == ServicingCompleteTaskName)
    {
        registered = BackgroundTaskSample::ServicingCompleteTaskRegistered;
    }
    else if (name == TimeTriggeredTaskName)
    {
        registered = BackgroundTaskSample::TimeTriggeredTaskRegistered;
    }
    else if (name == ApplicationTriggerTaskName)
    {
        registered = BackgroundTaskSample::ApplicationTriggerTaskRegistered;
    }
    else if (name == GroupedBackgroundTaskName)
    {
        registered = BackgroundTaskSample::GroupedBackgroundTaskRegistered;
    }

    String^ status = registered ? "Registered" : "Unregistered";

    if (TaskStatuses->HasKey(name))
    {
        status += " - " + TaskStatuses->Lookup(name)->ToString();
    }

    return status;
}

BackgroundTaskRegistration^ BackgroundTaskSample::RegisterBackgroundTask(String^ taskEntryPoint, String^ name, IBackgroundTrigger^ trigger, IBackgroundCondition^ condition, BackgroundTaskRegistrationGroup^ group)
{
    if (TaskRequiresBackgroundAccess(name))
    {
        BackgroundExecutionManager::RequestAccessAsync();
    }

    auto builder = ref new BackgroundTaskBuilder();

    builder->Name = name;

    if (taskEntryPoint != nullptr)
    {
        // If you leave the TaskEntryPoint at its default value, then the task runs
        // inside the main process from OnBackgroundActivated rather than as a separate process.
        builder->TaskEntryPoint = taskEntryPoint;
    }

    builder->SetTrigger(trigger);

    if (condition != nullptr)
    {
        builder->AddCondition(condition);

        //
        // If the condition changes while the background task is executing then it will
        // be canceled.
        //
        builder->CancelOnConditionLoss = true;
    }

    if (group != nullptr)
    {
        builder->TaskGroup = group;
    }

    auto task = builder->Register();

    UpdateBackgroundTaskRegistrationStatus(name, true);

    //
    // Remove previous completion status.
    //
    RemoveBackgroundTaskStatus(name);

    return task;
}

bool BackgroundTaskSample::TaskRequiresBackgroundAccess(String^ name)
{
    if ((name == TimeTriggeredTaskName) ||
        (name == ApplicationTriggerTaskName))
    {
        return true;
    }
    else
    {
        return false;
    }
}

void BackgroundTaskSample::UnregisterBackgroundTasks(String^ name, BackgroundTaskRegistrationGroup^ group)
{
    //
    // If the given task group is registered then loop through all background tasks associated with it
    // and unregister any with the name passed into this function.
    //
    if (group != nullptr)
    {
        for (auto pair : group->AllTasks)
        {
            auto task = pair->Value;
            if (task->Name == name)
            {
                task->Unregister(true);
            }
        }
    }
    else
    {
        //
        // Loop through all ungrouped background tasks and unregister any with the name passed into this function.
        //
        for (auto pair : BackgroundTaskRegistration::AllTasks)
        {
            auto task = pair->Value;
            if (task->Name == name)
            {
                task->Unregister(true);
            }
        }
    }

    UpdateBackgroundTaskRegistrationStatus(name, false);
}


BackgroundTaskRegistrationGroup^ BackgroundTaskSample::GetTaskGroup(String^ id, String^ groupName)
{
    auto group = BackgroundTaskRegistration::GetTaskGroup(id);

    if (group == nullptr)
    {
        group = ref new BackgroundTaskRegistrationGroup(id, groupName);
    }

    return group;
}


void BackgroundTaskSample::UpdateBackgroundTaskRegistrationStatus(String^ name, bool registered)
{
    if (name == SampleBackgroundTaskName)
    {
        BackgroundTaskSample::SampleBackgroundTaskRegistered = registered;
    }
    else if (name == SampleBackgroundTaskWithConditionName)
    {
        BackgroundTaskSample::SampleBackgroundTaskWithConditionRegistered = registered;
    }
    else if (name == ServicingCompleteTaskName)
    {
        BackgroundTaskSample::ServicingCompleteTaskRegistered = registered;
    }
    else if (name == TimeTriggeredTaskName)
    {
        BackgroundTaskSample::TimeTriggeredTaskRegistered = registered;
    }
    else if (name == ApplicationTriggerTaskName)
    {
        BackgroundTaskSample::ApplicationTriggerTaskRegistered = registered;
    }
    else if (name == GroupedBackgroundTaskName)
    {
        BackgroundTaskSample::GroupedBackgroundTaskRegistered = registered;
    }
}

void BackgroundTaskSample::RemoveBackgroundTaskStatus(String^ name)
{
    if (TaskStatuses->HasKey(name))
    {
        TaskStatuses->Remove(name);
    }
}

void App::OnBackgroundActivated(BackgroundActivatedEventArgs^ args)
{
    BackgroundActivity::Start(args->TaskInstance);
}

void App::Partial_Construct()
{
    auto group = BackgroundTaskSample::GetTaskGroup(BackgroundTaskGroupId, BackgroundTaskGroupFriendlyName);
    group->BackgroundActivated += ref new TypedEventHandler<BackgroundTaskRegistrationGroup ^, BackgroundActivatedEventArgs ^>(&BackgroundActivity::OnStart, CallbackContext::Same);
}
