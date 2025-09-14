# Keyboard Control

A Windows desktop application that provides system administrators and power users with the ability to enable and disable the internal keyboard driver through a simple graphical interface.

## Overview

Keyboard Control is a C# Windows Forms application designed to manage the internal keyboard driver (`i8042prt`) on Windows systems. This tool is particularly useful for system maintenance, security purposes, and controlled environments where temporary keyboard access restriction is required.

## Features

- **Simple Interface**: Clean and intuitive GUI with two primary functions
- **Administrator Privileges**: Secure execution with elevated permissions
- **System Integration**: Executes Windows service configuration commands via command line
- **Immediate Feedback**: Real-time status messages for all operations
- **Safe Operation**: Built-in error handling and validation

## Requirements

- Windows 10/11 or Windows Server 2016+
- .NET 8.0 Runtime (included in Windows 10 version 1903+)
- Administrator privileges
- System restart required after configuration changes

## Installation

### Option 1: Download Executable
1. Download the latest release from the releases page
2. Right-click the executable and select "Run as administrator"
3. Follow the on-screen instructions

### Option 2: Build from Source
```bash
git clone https://github.com/nuzael/keyboard-control.git
cd keyboard-control
dotnet build --configuration Release
```

The compiled executable will be located in `bin/Release/net8.0-windows/KeyboardControl.exe`

## Usage

### Running the Application
1. Launch the application with administrator privileges
2. The main window will display two options:
   - **Disable Keyboard**: Disables the internal keyboard driver
   - **Enable Keyboard**: Re-enables the internal keyboard driver

### Important Notes
- **System Restart Required**: Changes to the keyboard driver configuration only take effect after a system restart
- **External Keyboard**: If you disable the internal keyboard, ensure you have an external USB keyboard available for system navigation
- **Safe Mode**: In case of issues, you can always access Safe Mode to re-enable the keyboard driver

### Operation Flow
1. Click either "Disable Keyboard" or "Enable Keyboard"
2. The operation executes immediately (no confirmation dialog)
3. Restart your computer to apply changes
4. Verify the keyboard functionality after restart

## Technical Details

### System Commands
The application executes the following Windows service configuration commands:

**Disable Keyboard:**
```cmd
sc config i8042prt start= disabled
```

**Enable Keyboard:**
```cmd
sc config i8042prt start= auto
```

### Architecture
- **Framework**: .NET 8.0 with Windows Forms
- **Language**: C#
- **Target**: Windows Desktop Application
- **Privileges**: Requires Administrator execution level
- **Service**: Modifies the `i8042prt` driver configuration

## Use Cases

### System Administration
- Temporary keyboard lockdown during maintenance windows
- Preventing unauthorized input during system updates
- Creating controlled environments for specific tasks

### Security Applications
- Restricting keyboard access in public terminals
- Preventing keylogging attempts on sensitive systems
- Implementing multi-factor authentication workflows

### Hardware Management
- Testing external input devices without interference
- Troubleshooting keyboard-related hardware issues
- Preparing systems for keyboard replacement

## Troubleshooting

### Common Issues

**Application won't start:**
- Ensure you're running with administrator privileges
- Check that .NET 8.0 is installed on your system

**Keyboard remains active after disabling:**
- Restart your computer - changes require a system reboot
- Verify the service configuration using `sc query i8042prt`

**Unable to re-enable keyboard:**
- Boot into Safe Mode and run the application
- Use an external USB keyboard if available
- Access Device Manager to manually enable the keyboard driver

### Recovery Methods
1. **Safe Mode**: Boot into Safe Mode and run the application to re-enable
2. **External Keyboard**: Use a USB keyboard to navigate and re-enable
3. **Device Manager**: Manually enable the keyboard device in Device Manager
4. **System Restore**: Restore to a previous system state if necessary

## Security Considerations

- This application requires administrator privileges and modifies system drivers
- Only use on systems you own or have explicit permission to modify
- Always test in a safe environment before deploying in production
- Keep backup recovery methods available (external keyboard, Safe Mode access)

## Contributing

Contributions are welcome! Please feel free to submit pull requests or open issues for bugs and feature requests.

### Development Setup
```bash
git clone https://github.com/nuzael/keyboard-control.git
cd keyboard-control
dotnet restore
dotnet build
```

## License

This project is licensed under the GNU General Public License v3.0 - see the [LICENSE](LICENSE) file for details.

## Disclaimer

This software is provided "as is" without warranty of any kind. The authors are not responsible for any damage or data loss that may occur from the use of this application. Use at your own risk and always ensure you have proper backup and recovery procedures in place.

**Important**: Always test this application in a controlled environment before using it on production systems. Ensure you have alternative input methods available before disabling your primary keyboard.