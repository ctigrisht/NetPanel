# NetPanel
Panel for managing apps hosted on a linux machine

## Contributors
All help is appreciated, just message me on discord `flkXI#3462`

## Requirements
* Local MongoDB install
* .NET Core 3.1 Runtime (or compile as self contained, see https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-publish)

## All planned functionalities
### Hosted Applications Management
* Choice between binary application startup or script startup
* Upload and manage files of application directory directly from the interface
* Users with custom roles that can be added to apps for remote management 
### Customization
* Run ES6 Scripts through API provided in app (Javascript), save them per app or globally
### System Management
* User accounts with custom ranks and permissions, scriptable permissions through ES6
* Get an APT Repository list of packages to install (debian)
* Execute bash commands, with sudo access only for scripted permissions
### RCON
* Run ES6, bash/dash, shell scripts on a timely basis 
### Support
* Support is planned for all major distros, but right now I am working with debian/ubuntu
### Security
* Ability to add remote email server for OTP access on the web interface