Codename Orleans v0.9 Preview April 2014
========================================

What is Orleans?
----------------
http://orleans.codeplex.com

Orleans is a framework for building highly-scalable services for cloud and on-premise deployment.
Its programming model assumes much of the burden involved in developing, deploying, 
and operating a highly scalable application running on potentially unreliable servers. 
Orleans provides a higher-level programming model, significantly reducing the amount of work 
that developers need to do while easing the transition from desktop or client/server systems 
to cloud-scale distributed applications.

This preview release is intended to gather your feedback and ideas around the technology,
which in turn will guide our investments and strategy around it.


License
-------

The Orleans SDK preview release is for evaluation purposes only. The license terms are spelled out
in the file 'License.rtf' directly under the installation folder.

The Orleans SDK preview release includes binaries from Windows Azure SDK v2.2. Its license terms are
spelled out in the file 'Azure SDK License.rtf' directly under the installation folder.


What is in this release?
------------------------
1. Binaries for server- and client-side runtime functionality
2. Reference documentation
4. Visual Studio 2012 and 2013 extensions (project and item templates)
5. A local development/execution environment
5. Scripts for remote deployment


Folder Structure
----------------

[ORLEANS-SDK]
 +- SDK
 |  +-- Docs                              - API reference documentation. Tutorials are available online.
 |  +-- Binaries                          - Pre-built binary copies of Orleans system runtime and sample apps
 |  |   +-- OrleansClient                 - Pre-built copy of Orleans client runtime binaries
 |  |   +-- OrleansServer                 - Pre-built copy of Orleans system runtime binaries
 |  +-- LocalSilo                         - A local pre-configured execution environment
 |  +-- RemoteDeployment                  - Sample configuration files and PowerShell scripts for deployment to an on-premise cluster


Samples
-------

Samples for this preview release are available at https://orleans.codeplex.com.


Online Documentation
------------------

Live (tutorial) documentation for Orleans is available at https://orleans.codeplex.com/documentation



