# ffs-util


### Description 

FFS (Fill Free Space) is an utility to fill up all available free space on the drive.
This utility is created to be used for testing purposes (e.g. resilience testing).

### How it works?
FFS creates empty file with defined file length. So, this file will be just a file declaration for the file system. Such file can be created very quickly and there is no need to write some data to the file, so hard disk health is not suffering.

### Installation requirements

Note: Pre-compiled version can be found [here](https://github.com/kungfux/ffs-util/releases)

In order to build from scratch, it is needed to build the project in usual C# way.

.NET Framework 2.0 is required to build the project.

### Contribution guidelines

Using standard pull requests, creating issues etc.
