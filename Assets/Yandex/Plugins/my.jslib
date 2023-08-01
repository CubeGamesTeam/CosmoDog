mergeInto(LibraryManager.library, {


  Hello: function () {
    console.log("Hello world!");
  },

  TryToInitYSDKFromUnity: function (){
    initGame();
  },

  TryToGetPlayerFromUnity: function () {
    console.log("TryToGetPlayerFromUnity!");
    initPlayer();
    //ysdk.getPlayer().then(_player => {player = _player; myGameInstance.SendMessage('InitScene', 'PlayerReady', 1); console.log(player.getName()); return player;});
  },


  TryToGetDeviceFromUnity: function () {
    getTypeDevice();
      //ysdk.deviceInfo.isDesktop().then(_deviceInfo => {deviceInfo = _deviceInfo; console.log(deviceInfo);})
  },


  AuthExtern: function () {
    auth(); 
  },


  GiveMePlayerData: function () {
    //myGameInstance.SendMessage('Yandex', 'SetName', player.getName());
    //myGameInstance.SendMessage('Yandex', 'SetPhoto', player.getPhoto("small"));
    myGameInstance.SendMessage('Yandex', 'SetName', playerName);
    myGameInstance.SendMessage('Yandex', 'SetPhoto', playerIconSmall);
  },


  RateGame: function () {

    ysdk.feedback.canReview()
    .then(({ value, reason }) => {
      if (value) {
        ysdk.feedback.requestReview()
        .then(({ feedbackSent }) => {
          console.log(feedbackSent);
        })
      } else {
        console.log(reason)
      }
    })
  },


  SaveExtern: function (date) {
    var dateString = UTF8ToString(date);
    var myobj = JSON.parse(dateString);
    player.setData(myobj);
  },


  LoadExtern: function () {
    //player.getData().then(_date => {
      //const myJSON = JSON.stringify(_date);
      //myGameInstance.SendMessage('Progress', 'Load', myJSON);
   // });
    myGameInstance.SendMessage('Progress', 'Load', playerBestResult);
  },


  SetToLeaderboard: function (value){
    ysdk.getLeaderboards()
    .then(lb => {
      lb.setLeaderboardScore('Score1', value);
    });
  },


});