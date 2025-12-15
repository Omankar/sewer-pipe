mergeInto(LibraryManager.library, {
  SendToReact: function(namePtr) {
    const objectName = UTF8ToString(namePtr);
    if (window.unityObjectClicked) {
      window.unityObjectClicked(objectName);
    }
  }
});