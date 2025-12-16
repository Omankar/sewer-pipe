mergeInto(LibraryManager.library, {
  OnUnityObjectClicked: function (ptr) {
    var name = UTF8ToString(ptr);
    console.log("Unity clicked:", name);

    if (window.unityObjectClicked) {
      window.unityObjectClicked(name);
    }
  }
});