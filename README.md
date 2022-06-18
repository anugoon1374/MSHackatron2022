# MSHackatron2022 - Overseer by Unit B
This repository contains the prototype code of the team "Overseer by Unit B" for [Microsoft Virtual Hackathon 2022](https://www.hackerearth.com/challenges/hackathon/microsoft-virtual-hackathon-2022).

## Structure
This repository have to two folder :
1. IoT-Code folder contains the C# code for simulating signals from factory IoT device in the manufacturing line.
2. ML-Code folder contains the Juniper Notebook code for Machine Learning Model training. The machine learning model is use with camera installed in the manufacturing line to detect the defective product.

## About ML-Code
- Juniper Notebook code (.ipynb) can be open with Google Colabs or Jupyter Notebooks in Visual Studio Code.
- The algorithm we use to traing this ML model is the Convolution Neural Network (CNN).
- ML-Code folder does not contain all training datasets, only some samples for the prototype.

## About IoT-Code
- IoT-Code does not contain a connection string and shared access signature (SAS) to access Azure IoT Hub.
- IoT-Code solution can be open with Visual Studio IDE or Visual Studio Code (require Azure IoT Device Workbench extension and .NET 6 SDK installed)
- To build IoT-Code, it requires .NET 6 framework, C# 11, and Azure IoT SDK installed on the machine.