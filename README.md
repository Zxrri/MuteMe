# 🔇 MuteMe

MuteMe is a lightweight tray utility that automatically mutes your microphone and/or system audio after inactivity.

##  Features

- Detects idle time based on keyboard & mouse inactivity
- Auto-mutes system volume and/or microphone
- Auto-unmutes when you return
- Tray icon with right-click access to:
  - Settings (idle timeout, mute behavior)
  - Exit
- Balloon tips for mute/unmute (optional)

## ⚙️ Settings

Settings are saved in a local `settings.json` file and include:

- `IdleTimeoutSeconds`: How long before muting
- `MuteSystem`: Whether to mute system volume
- `MuteMic`: Whether to mute mic
- `ShowNotifications`: Show tray notifications

## 🛠 Built With

- C# + WinForms (.NET 8)
- NAudio for volume/mic control
- System.Text.Json for config

## 🚀 Downloads

Visit the [Releases tab](https://github.com/YOUR_USERNAME/MuteMe/releases) to download the latest `.exe`.

## 📥 How to Use

1. Download the `.zip` or `.exe` from the release
2. Launch MuteMe — it will start minimized to tray
3. Right-click the tray icon to access settings

---

Made with ☕ and frustration over noisy meetings
