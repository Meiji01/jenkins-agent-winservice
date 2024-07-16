# Jenkins Agent WinService
An open-source windows service application to contain Jenkins Agent Jar file and run as a windows service. Current release supports http connection only
## Compiler Prerequisites
If you want to compile the project, the below minimum prerequisite are required
- Compiler  
Visual Studio 2022 (Visual Basic)  
Java (Version that runs the agent.jar of Jenkins) 
 
## Installation
If done compiling or you wish to install the official git releases, please follow step by step instructions
- Prerequisite  
Windows 10/11/Server  
.Net Framework 4.7.2 is installed  
Administrator rights to install the application to windows service  

- Step 1 - Download the official binary releases (use the latest to insure stability and up to date capabilities) in [Section `Releases`](https://github.com/Meiji01/jenkins-agent-winservice/releases) or use your compiled version
- Step 2 - Extract the binary _(AgentContainer.exe and conf.properties)_ to the desire directory
- Step 3 - Create and configure an agent in Jenkins (if you still dont have one) 
- Step 4 - Configure **conf.properties** file based on the https connection info of your agent
 ```
#Properties
jenkinsagentpath=<agentpath> i.e "C:\Jenkins\agent.jar"
jenkinsurl=<jenkins home url> i.e https://myjenkins.net.local/jenkins/
jenkinssecret=<secret id>
agentname=<node name> i.e "Node1"
workDir="<jenkins working dir> i.e "C:\Jenkins"
isWebSocket=<true/false> i.e false
```
- Step 6 - Register the **AgentContainer.exe** as a window service using the below command in windows command prompt elevated mode (Administrator access is required)
```
sc.exe create "JenkinsAgent" binPath= "<location path of AgentContainer.exe"
```
> Sample:
sc.exe create "JenkinsAgent" binPath= "C:\Jenkins\AgentContainer.exe"
- Step 5 - Check if JenkinsAgent service is already added in your windows service and try to Start
- If you wish to delete the windows service, use the below command in elevated mode
```
sc delete "JenkinsAgent"
````
## Issues/Defects
Please file issues/defect in Git