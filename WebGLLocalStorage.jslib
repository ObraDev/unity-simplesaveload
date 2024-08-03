mergeInto(LibraryManager.library, {
    SaveToLocalStorage: function (key, value) {
        localStorage.setItem(Pointer_stringify(key), Pointer_stringify(value));
    },
    LoadFromLocalStorage: function (key) {
        var value = localStorage.getItem(Pointer_stringify(key));
        if (value === null) value = "";
        var lengthBytes = lengthBytesUTF8(value) + 1;
        var stringOnWasmHeap = _malloc(lengthBytes);
        stringToUTF8(value, stringOnWasmHeap, lengthBytes);
        return stringOnWasmHeap;
    },
    SaveIntToLocalStorage: function (key, value) {
        localStorage.setItem(Pointer_stringify(key), value.toString());
    },
    LoadIntFromLocalStorage: function (key) {
        var value = parseInt(localStorage.getItem(Pointer_stringify(key)), 10);
        return isNaN(value) ? 0 : value;
    },
    SaveFloatToLocalStorage: function (key, value) {
        localStorage.setItem(Pointer_stringify(key), value.toString());
    },
    LoadFloatFromLocalStorage: function (key) {
        var value = parseFloat(localStorage.getItem(Pointer_stringify(key)));
        return isNaN(value) ? 0.0 : value;
    },
    HasKeyInLocalStorage: function (key) {
        return localStorage.getItem(Pointer_stringify(key)) !== null ? 1 : 0;
    },
    RemoveFromLocalStorage: function (key) {
        localStorage.removeItem(Pointer_stringify(key));
    },
    ClearLocalStorage: function () {
        localStorage.clear();
    }
});

