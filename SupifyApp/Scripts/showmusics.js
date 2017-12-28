$(document).ready(function () {
    alert("hello");
    $('tr').each(function () {
        alert(this.id);
    });
});