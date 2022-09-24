# MWBytesChallenge

Solution for a windows service that logs access to specific folderes

## Getting Started

### Dependencies

* restore nuget packages, only should restore NLog.

### Installing

* publish `FolderWatchInstaller` into desired directory.

### Executing program

* Must run cmd with administrator privileges
```
FolderWatchInstaller.exe [-install|-uninstall]
-install: creates the service as 'FolderWatch' and attemps to start it.
-uninstall: stops the service and deletes it from services
```


## Authors

Tobías Girado
