# TritonBikeWatch - Campus Bicycle Anti-Theft System
### UCSD ECE 196 FALL 2023  
#### Created by Team 1: `TritonBikeWatch` - Jia Ming (Jimmy) Qiu, Alic Luna, Nathan Chong

![UCSD ECE Logo](https://raw.githubusercontent.com/jiamingqiu-jimmy/TritonBikeWatch/main/Assets/ECE_Logo.png)

## Table of Contents

1. [Project Description](#project-description)
    1. [Introduction](#introduction)
        1. [High-level Approach](#high-level-approach)
        2. [First Hardware Solution - Bicycle Device PCB](#first-hardware-solution---bicycle-device-pcb)
        3. [Second Hardware Solution - Security Camera PCB](#second-hardware-solution---security-camera-pcb)
        4. [Software Solution - Web & Mobile Application](#software-solution---web--mobile-application)
    2. [Video Demo](#video-demo)
    3. [Slide Deck](#slide-deck)
    4. [Tutorial Link](#tutorial-link)
2. [Schematics](#schematics)
3. [Resources](#resources)
    1. [Software Resources](#software-resources)
    2. [Hardware Resources](#hardware-resources)
4. [Meet The Team](#meet-the-team)
    1. [Jia Ming (Jimmy) Qiu](#jia-ming-jimmy-qiu)
    2. [Alic Luna](#alic-luna)
    3. [Nathan Chong](#nathan-chong)

## Project Description

### Introduction

#### High-level Approach
Our solution to mitigate campus bicycle theft is a three-prong approach involving two hardware solutions and one software solution combined together into one system. Our goal for our system is to improve awareness and response time to ongoing bicycle theft and give students an ease of mind and a feeling of security when parking their bicycles on campus.

#### First Hardware Solution - Bicycle Device PCB
Our first hardware solution is a PCB that can be attached to a bicycle that will alert the owner on their web/mobile devices if there are any recognized sounds of a bicycle lock being cut, and also will alert the owner if there is detection of motion of the bicycle when the owner has specified they are in class. 

#### Second Hardware Solution - Security Camera PCB
Our second hardware solution is a PCB that will overlook a bicycle parking location and be able to stream video feed to the user if they want to check on their bicycle,  it should also be able to recognize when a specific bicycle is being moved when it shouldn’t be and alert the user. Eventually it should also be able to record and gather evidence when a bicycle is stolen. 

#### Software Solution - Web & Mobile Application
Our third approach is a web application that will tie the two hardware solutions together by handling the logic of how to alert the mobile / web applications given a signal from either of the two PCBs. This will be both a web and mobile application where users can view video feeds of a parking spot, handle alerts from application and alert the corresponding user, and be a place where users manually alert others of suspicious activity.

### Video Demo

[Youtube Embed Link]

### Slide Deck

[Google Slides Link](https://docs.google.com/presentation/d/1Svcvlm2VV6MllKzdXzbsiNCcoLggKlQp_iDzHF-oDoM/edit?usp=sharing)

### Tutorial Link 

[Tutorial Google Docs Link](https://docs.google.com/document/d/1eIxykKeZzMzo6rNRDwa9eUPzwEGaHyKE7Q5rheZnAVY/edit?usp=sharing)

### Website Links

[Main Application](https://ucsdtritonbikewatch.azurewebsites.net/)
[Bike Device Alert Link](https://ucsdtritonbikewatch.azurewebsites.net/DeviceAlert?DeviceName=BikeDevice)
[Camera Device Alert Link](https://ucsdtritonbikewatch.azurewebsites.net/DeviceAlert?DeviceName=CameraDevice)

## Schematics

Website View
<img src="https://github.com/jiamingqiu-jimmy/TritonBikeWatch/blob/main/Assets/WebsiteView.png?raw=true" width=100% height=100%>

Web Application Architecture
<img src="https://github.com/jiamingqiu-jimmy/TritonBikeWatch/blob/main/Assets/AppArchitecture.png?raw=true" width=100% height=100%>

Azure Deployment
<img src="https://github.com/jiamingqiu-jimmy/TritonBikeWatch/blob/main/Assets/AzureDeployment.png?raw=true" width=100% height=100%>

Camera Device
<img src="https://github.com/jiamingqiu-jimmy/TritonBikeWatch/blob/main/Assets/CameraDevice.png?raw=true" width=30% height=30%>

Bike Device
<img src="https://github.com/jiamingqiu-jimmy/TritonBikeWatch/blob/main/Assets/BikeDevice.png?raw=true" width=30% height=30%>

## Resources

### Software Resources

1. [Azure Cloud $100 Credit](https://azure.microsoft.com/en-us/free/students)
2. [Github Students](https://education.github.com/students)
3. [.NET MAUI](https://dotnet.microsoft.com/en-us/apps/maui)
4. [.NET Blazor Hybrid](https://learn.microsoft.com/en-us/aspnet/core/blazor/hybrid/?view=aspnetcore-7.0)
5. [.NET Blazor WASM](https://learn.microsoft.com/en-us/aspnet/core/blazor/?view=aspnetcore-7.0)
6. [Azure Kubernetes Service](https://azure.microsoft.com/en-us/products/kubernetes-service)

### Hardware Resources

1. [Circuit IO](https://www.circuito.io/)
1. [Arduino](https://www.arduino.cc/)
1. [Edge Impulse](https://edgeimpulse.com/)
1. [ESP32-CAM](https://github.com/yoursunny/esp32cam)

## Meet The Team

<img src="https://github.com/jiamingqiu-jimmy/TritonBikeWatch/blob/main/Assets/GroupPhoto.jpg?raw=true" width=50% height=50%>

### Jia Ming (Jimmy) Qiu

<img src="https://github.com/jiamingqiu-jimmy/TritonBikeWatch/blob/main/Assets/Jimmy.jpg?raw=true" width=50% height=50%>

Hello! My name is Jimmy an I'm a second year Machine Learning Data Science Masters student at UCSD and I'm also a a full time Software Engineer at Verint Systems. I'm passionate about software and software systems, and I'm excited to have been working on this project integrating hardware and software with this team. I want to explore as much as I can about all the different connections software has with other disciplines and eventually become an expert in the software field!

### Alic Luna

<img src="https://github.com/jiamingqiu-jimmy/TritonBikeWatch/blob/main/Assets/Alic.jpg?raw=true" width=50% height=50%>

Greetings, I am Alic Luna, a senior majoring in electrical engineering with a specialized focus on Power Systems. Upon completion of my academic pursuits, my aspiration is to contribute to the field by engaging in substation design or specializing in protection and controls for power grid systems. In my leisure, I enjoy exploring diverse culinary experiences, watching films, and appreciating craft beers. The objective of my current project is to gain proficiency in embedded systems and computer vision. Specifically, I aim to develop an object-detecting security camera designed to deter and prevent instances of bike theft.

### Nathan Chong

<img src="https://github.com/jiamingqiu-jimmy/TritonBikeWatch/blob/main/Assets/Nathan.jpg?raw=true" width=50% height=50%>

Hello, I'm Nathan Chong, a senior at UCSD Marshall College majoring in electrical engineering. Beyond the world of circuits and equations, I find joy in playing volleyball, experimenting with new recipes in the kitchen, and immersing myself in the thrilling realms of gaming. A vanilla cold brew is my go-to beverage for those moments of peak awareness. As I embark on this project, my goal is to engineer a bike device capable of detecting sudden movements and sounds, blending my passion for technology with a commitment to safety and innovation.
