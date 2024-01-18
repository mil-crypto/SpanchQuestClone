mergeInto(LibraryManager.library, {

  ShowAdv : function () {
    ysdk.adv.showFullscreenAdv({
      callbacks: {
        onClose: function(wasShown) {
          SendMessage('Main Camera', 'OnCloseBanner');  
        },
        onError: function(error) {
          // some action on error
        }
      }
    })  
  }
});