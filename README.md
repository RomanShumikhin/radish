# Introduction 
Radish is a simple client for accessing Redis. It is built using .Net Core and Avalonia so it works on Windows, Mac, and Linux.

# Build and Test
0. Install .Net Core 2.2 SDK or greater.
1. Clone the software - git clone https://github.com/cmbyerly/radish.git
2. cd to radish/Radish subdirectory.
3. Restore the NuGet packages - dotnet restore.
4. Build the project - dotnet build.
5. Run it - dotnet run.

# Deploy
If you want to deploy the project, here are the commands.  Execute these from the radish/Radish directory.
- Linux: dotnet publish --self-contained --runtime linux-x64 --output /path/to/directory
- Windows: dotnet publish --self-contained --runtime win-x64 --output C:\path\to\directory
- Mac: dotnet publish --self-contained --runtime osx-x64 --output /path/to/directory

You can see the entire RID catalog here: https://docs.microsoft.com/en-us/dotnet/core/rid-catalog

# Contribute
I have been adding features as I need them, but I would like to make it full featured.  If you want to contribute, please feel free to contact me.  I am always appreciative of people who can help out on stuff like this.

Things this project needs:
- Some graphics for the UI would be excellent!
- Some other people to help flesh out the following features: login with PEM, styling, and other items as needed.
- Feedback on features needed is also very nice.
