# economy for ZTZBX Framework

### **Requirements**
- [core-ztzbx](https://github.com/ZTZBX/core-ztzbx)
- [notification](https://github.com/ZTZBX/notification)
- [fivem-mysql](https://github.com/ZTZBX/fivem-mysql)


To edit it, open `economy.sln` in Visual Studio.

To build it, run `build.cmd`. To run it, run the following commands to make a symbolic link in your server data directory:

```dos
cd /d [PATH TO THIS RESOURCE]
mklink /d X:\cfx-server-data\resources\[local]\economy dist
```

Afterwards, you can use `ensure economy` in your server.cfg or server console to start the resource.

### **Client Side**
**Get Current Money on hand**
```cs
// Easy and simple
int playerMoney = Exports["economy"].getHandMoney()
```
---
**Remove Current Money on hand**
```cs
// Easy and simple
int quantityToRemoveFromHand = 10;
Exports["economy"].removeHandMoney(quantityToRemoveFromHand)
```
---
**Add Current Money on hand**
```cs
// Easy and simple
int quantityToAddFromHand = 10;
Exports["economy"].AddHandMoney(quantityToAddFromHand)
```
---