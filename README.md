[![Analytics](https://ga-beacon.appspot.com/UA-121798497-2/github/eviabs/downtify-premium)](https://github.com/igrigorik/ga-beacon)
[![Is this project still maintained?](https://img.shields.io/badge/maintained%3F-yes-green.svg?style=plastic)](https://github.com/badges/shields)

### What is Downtify?

Downtify is an open source Spofity downloader which makes it possible to download all your favourite songs and/or
playlists directly from Spotify.

![down-prem](https://user-images.githubusercontent.com/14614396/52458742-e7add380-2b69-11e9-8194-99e9131dc5b2.png)


A Spotify Premium account is required. 

This project was forked from [Shawak/downtify](https://github.com/Shawak/downtify) and was modified a bit.


### Usage

To use Downtify, you need to clone/download the repo and edit the `config.xml` file:
```xml
<configuration>
  <username>username</username>
  <password>password</password>
  <language>en</language>
  <file_exists>SKIP</file_exists>
  <clientId>clientId</clientId>
  <clientSecret>clientSecret</clientSecret>
  <volume_normalization>false</volume_normalization>
</configuration>
```
`username` + `password` must be valid Premium user credentials.

`clientId` + `clientSecret` should be retrived from [here](https://developer.spotify.com/documentation/general/guides/app-settings/#register-your-app).

### Downloading

You can download the latest version [here](https://github.com/eviabs/downtify-premium/archive/master.zip).

### Known Issues ###
1. Playlists cannot be loaded at the moment. To download a full playlist follow this:
    - Open a playlist on Spotify
   - Select a single song
   - Press CTRL+A to select all songs
   - Press CTRL+C to copy all URIs to clipboard
   - Paste this in `downtify-premium` textbox
   - Press enter, and all of the songs will be loaded

### Bugs

Feel free to help developing this mod by reporting any issues at our [bug tracker](https://github.com/eviabs/downtify-premium/issues).

### License

Downtify is licensed under the GNU General Public License v3, for more information please check out the [license information](https://github.com/eviabs/downtify-premium/blob/master/LICENSE).
