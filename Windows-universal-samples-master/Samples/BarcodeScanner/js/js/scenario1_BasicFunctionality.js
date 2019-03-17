﻿//*********************************************************
//
// Copyright (c) Microsoft. All rights reserved.
// This code is licensed under the MIT License (MIT).
// THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
// IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
// PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
//
//*********************************************************

(function () {
    "use strict";

    var scenarioStartScanButton;
    var scenarioEndScanButton;

    var page = WinJS.UI.Pages.define("/html/scenario1_BasicFunctionality.html", {

        // On ready - set button states and add event listeners to the buttons.
        ready: function (element, options) {

            WinJS.log("Click the start scanning button to begin.", "sample", "status");

            scenarioStartScanButton = document.getElementById("scenarioStartScanButton");
            scenarioEndScanButton = document.getElementById("scenarioEndScanButton");

            scenarioStartScanButton.addEventListener("click", startReceivingData, false);
            scenarioEndScanButton.addEventListener("click", endReceivingData, false);
            scenarioStartScanButton.disabled = false;
            scenarioEndScanButton.disabled = true;
        },

        // On unload - clean up if claimedscanner object is not null.
        unload: function () {
            if (scenarioStartScanButton.disabled) {
                if (_claimedScanner !== null) {

                    // Remove event listeners that were added before and close.
                    _claimedScanner.removeEventListener("datareceived", onDataReceived);
                    _claimedScanner.removeEventListener("releasedevicerequested", onReleasedeviceRequested);
                    _claimedScanner.close();
                    _claimedScanner = null;
                }

                if (_scanner !== null) {
                    _scanner.close();
                    _scanner = null;
                }
            }
        }
    });

    var _scanner = null;
    var _claimedScanner = null;

    // Acquires the default barcode scanner and claims it. Once claimed, it adds event listeners for datareceived and releasedevicerequested events.
    // On error, it logs the error message.
    function startReceivingData() {
        scenarioStartScanButton.disabled = true;

        // Acquire the barcode scanner.
        WinJS.log("Acquiring barcode scanner object.", "sample", "status")

        SdkSample.getFirstBarcodeScannerAsync().done(function (scanner) {
            if (scanner) {
                _scanner = scanner;

                // After successful creation, claim the scanner for exclusive use and enable it so that data received events are raised.
                scanner.claimScannerAsync().done(function (claimedScanner) {
                    if (claimedScanner) {
                        _claimedScanner = claimedScanner;

                        // Ask the API to decode the data by default. By setting this, API will decode the raw data from the barcode scanner and
                        // send the ScanDataLabel and ScanDataType in the DataReceived event
                        claimedScanner.isDecodeDataEnabled = true;

                        // After successfully claiming, attach the datareceived event handler.
                        claimedScanner.addEventListener("datareceived", onDataReceived);

                        // It is always a good idea to have a release device requested event handler. If this event is not handled, there are chances of another app can
                        // claim ownsership of the barcode scanner.
                        claimedScanner.addEventListener("releasedevicerequested", onReleasedeviceRequested);

                        // Enable the scanner.
                        // Note: If the scanner is not enabled (i.e. enableAsync not called), attaching the event handler will not be any useful because the API will not fire the event
                        // if the claimedScanner has not beed Enabled
                        claimedScanner.enableAsync().done(function () {
                            WinJS.log("Ready to scan. Device ID: " + claimedScanner.deviceId, "sample", "status");
                            scenarioEndScanButton.disabled = false;
                        });
                    } else {
                        WinJS.log("Claim barcode scanner failed.", "sample", "error");
                        scenarioStartScanButton.disabled = false;
                    }
                });
            } else {
                WinJS.log("Barcode scanner not found. Please connect a barcode scanner.", "sample", "error");
                scenarioStartScanButton.disabled = false;
            }
        });
    }

    // Event handler for the Release Device Requested event fired when barcode scanner receives Claim request from another application
    function onReleasedeviceRequested(args) {
        _claimedScanner.retainDevice();
        WinJS.log("Event ReleaseDeviceRequested received. Retaining the barcode scanner.", "sample", "status");
    }

    // Event handler for the DataReceived event fired when a barcode is scanned by the barcode scanner
    function onDataReceived(args) {
        var tempScanType = Windows.Devices.PointOfService.BarcodeSymbologies.getName(args.report.scanDataType);

        document.getElementById("scenarioOutputScanDataType").textContent = tempScanType;
        document.getElementById("scenarioOutputScanData").textContent = getDataString(args.report.scanData);
        document.getElementById("scenarioOutputScanDataFormatted").textContent = getDataLabelString(args.report.scanDataLabel, args.report.scanDataType);
    }

    // This method removes the event listeners from the claimed scanner object if it is not null and then closes the claimed scanner so that someone else can use it.
    function endReceivingData() {
        if (_claimedScanner !== null) {
            _claimedScanner.removeEventListener("datareceived", onDataReceived);
            _claimedScanner.removeEventListener("releasedevicerequested", onReleasedeviceRequested);
            _claimedScanner.close();
            _claimedScanner = null;
        }

        if (_scanner !== null) {
            _scanner.close();
            _scanner = null;
        }

        // Reset button states
        WinJS.log("Click the start scanning button to begin.", "sample", "status");

        document.getElementById("scenarioStartScanButton").disabled = false;
        document.getElementById("scenarioEndScanButton").disabled = true;
        document.getElementById("scenarioOutputScanDataType").textContent = "No Data";
        document.getElementById("scenarioOutputScanData").textContent = "No Data";
        document.getElementById("scenarioOutputScanDataFormatted").textContent = "No Data";
    }

})();
