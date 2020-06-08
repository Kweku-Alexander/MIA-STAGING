function textonly(e)
{
    var code;
    if (!e) var e = window.event;
    if (e.keyCode) code = e.keyCode;
    else if (e.which) code = e.which;
    var character = String.fromCharCode(code);
    //alert('Character was ' + character);
    //alert(code);
    //if (code == 8) return true;
    var AllowRegex = /^[\ba-zA-Z\s-]$/;
    if (AllowRegex.test(character)) return true;
    return false;
}