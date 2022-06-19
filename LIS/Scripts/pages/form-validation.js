!function () {
    "use strict";
    var e = document.querySelectorAll(".needs-validation");
    Array.prototype.slice.call(e).forEach(function (t) {
        t.addEventListener("submit", function (e) { t.checkValidity() || (e.preventDefault(), e.stopPropagation()), t.classList.add("was-validated") }, !1)
    });

    var t = document.getElementById("form-validation-2"),
        s = document.getElementById("username"),
        n = document.getElementById("email"),
        r = document.getElementById("password"),
        l = document.getElementById("password2");
    function i(e, t) {
        var a = e.parentElement;
        console.log(a.children), a.children[1].classList.add("error");
        var s = a.querySelector("small"); s.innerText = t, s.classList.add("error"), s.classList.remove("success")
    }

    function c(e) {
        var t = e.parentElement; t.children[1].classList.remove("error"), t.children[1].classList.add("success"); var a = t.querySelector("small");
        a.classList.add("success"), a.classList.remove("error")
    }

    function d(e, t, a) { e.value.length < t ? i(e, "${getFieldName(input)} must be at least ${min} characters") : e.value.length > a ? i(e, "${getFieldName(input)} must be les than ${max} characters") : c(e) }
    t.addEventListener("submit", function (e) { var t, a; e.preventDefault(), [s, n, r, l].forEach(function (e) { "" === e.value.trim() ? i(e, "${getFieldName(input)} is required") : c(e) }), d(s, 3, 15), d(r, 6, 25), /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/.test((t = n).value.trim()) ? c(t) : i(t, "Email is not invalid"), a = l, r.value !== a.value && i(a, "Passwords do not match") })
}();