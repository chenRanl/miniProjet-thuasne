var readline = require('readline')
const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});

var firmware = new Array();
var user = new Array();

function isEmptyObject(obj){
    for (var n in obj) {
        return false
    }
    return true;
}

function isUserExist(ele,obj){
  for (var n in obj){
    if (ele == obj[n]){
      return true
    }
  }
  return false
}



function declarer(data){
  data = data.replace(/^(\s|{)+|(\s|})+$/g, '');
  var device = data.split(',')
  if (device[0] in firmware){
    console.log('SLB already declare');
  } else {
    firmware[device[0]] = device[1];
    console.log('OK');
    console.log(firmware);
  }
}

function associer(data){
  data = data.replace(/^(\s|{)+|(\s|})+$/g, '');
  var device = data.split(',')
  if (device[0] in user){
    console.log('SLB already have an USER');
    console.log(user);
  } else {
    if (isEmptyObject(user)){
      user[device[0]] = device[1];
      console.log('OK');
    } else {
        if (isUserExist(device[1],user)){
          console.log('USER already have its own SLB');
          console.log(user);
        } else {
          user[device[0]] = device[1];
          console.log('OK');
        }
    }
  }
}

function dissocier(data){
  data = data.replace(/^(\s|{)+|(\s|})+$/g, '');
  var device = data.split(',')
  if (device[0] in user){
    if (device[1] == user[device[0]]){
      delete user[device[0]];
      console.log('OK');
    } else {
      console.log('SLB and USER does not match');
    }
  } else {
    console.log('SLB does not have an USER');
    console.log(user);
  }
}

function MiseAJour(data){
  data = data.replace(/^(\s|{)+|(\s|})+$/g, '');
  var device = data.split(',')
  console.log(device)
  if (device[0] in firmware){
    user[device[0]] = device[1];
    console.log('OK');
  } else {
    console.log('SLB does not have an FIRMWARE');
    console.log("firmware list: ",firmware);
  }
}


rl.on('line',function(line){
  var tokens = line.split(' ')
  switch (tokens[0]) {
    case 'de':
      declarer(tokens[1]);
      break;
    case 'a':
      associer(tokens[1])
      break;
    case 'di':
      dissocier(tokens[1])
      break;
    case 'm':
      MiseAJour(tokens[1])
      break;
    case 'show':
      console.log('user list',user)
      console.log('firmware list',firmware)
    default:
      console.log('command not right')

  }
})
