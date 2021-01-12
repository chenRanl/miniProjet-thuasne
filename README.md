# miniProjet-thuasne
Start the programme by `node miniProjet.js`

## Notification
The command that you input should be in the forme like ```command {XX,YY}```

--There is only one {XX,YY} after command-- 

There are 5 commands viable:


- **de** : declare the Device with Firmware

  e.g.
  
  `de {SLB-01,FW-01}` return `OK`
  
  `de {SLB-01,FW-02}` return `SLB already declare`


- **a** : associate the Device with User
  e.g.
  
  `a {SLB-01,USER-01}` and  `a {SLB-02,USER-02}` return `OK`
  
  `a {SLB-01,USER-03}` return `SLB already have an USER`
  
  `a {SLB-33,USER-02}` return `USER already have its own SLB`

- **di** : dissociate the Device with User
  
  e.g.
  
  LIST User = {SLB-01,USER-01},{SLB-02,USER-02}
  
  `di {SLB-02,USER-02}` return `OK`
  
  `di {SLB-33,USER-01}` return `SLB does not have an USER`
  
  `di {SLB-01,USER-47}` return `SLB and USER does not match`

- **m** : update the firmware
  
  e.g. 
  
  LIST Firmware = {SLB-01,FW-01},{SLB-02,FW-01}
  
  `m {SLB-01,FW-03}` return `OK`
  
  `m {SLB-04,FW-03}` return `SLB does not have an FIRMWARE`

- **show** : show the lists of firmware and user

