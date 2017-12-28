$('#home_button').click(function () {
    window.location = '/home';
});

$("#input").on("click", function () { searchmusic($("#inputsearch").val()); });

function searchmusic(s) {
    $.ajax({
        type: "GET",
        url: "https://api.jamendo.com/v3.0/tracks",
        data: {
            client_id: '56d30c95',
            format: 'json',
            search: s,
            limit: 5
        },

        success: function (response) {
            tracks = response.results;
            $.each(tracks, function (i, track) {
                console.log(track);
                var trackName = track.name,
                time = track.duration,
                img = track.image,
                audio = track.audio,
                trackNumber = track.id;
                
                $('#search').append('<div class="row"><div class="col-md-2"><img src="' + img + '" /></div><div class="col-sm-1"></div><div class="col-md-8"><p></p><p><b>' + trackName + '</b></p><p>' + time + '"</p><input class="btn add" id="' + trackNumber + '" type="button" value="+ Add Music" onclick="addtrack(' + trackNumber + ')" /><br/><br/><audio preload id="audio1" controls="controls" src="' + audio + '">Your browser does not support HTML5 Audio!</audio></div></div><br/>')
            });
        }
    });
}
//Getting element id from jquery generated html

function addtrack(id) {
    alert(id);
    var data = { "id": id };
    alert(data);
    $.ajax({
        type: "POST",
        url: "/Player/Addtrack",
        data: data,
        dataType: 'json',
        success: function (id) {
    }
    });
}

$(document).ready(function () {
    $('.mclass').each(function () {
        var trid = this.id;
        alert(trid);
        //this.id pr avoir trackid
        $.ajax({
            type: "GET",
            url: "https://api.jamendo.com/v3.0/tracks",
            data: {
                client_id: '56d30c95',
                format: 'json',
                id: trid,
            },

            success: function (response) {
                var track = response.results[0];
                var trackName = track.name,
                time = track.duration,
                img = track.image,
                audio = track.audio,
                trackNumber = track.id;

                $("#"+trid).append('<td><p><b>' + trackName + '</b></p></td><td><p>' + time + '"</p></td><td><audio preload id="audio1" controls="controls" src="' + audio + '">Your browser does not support HTML5 Audio!</audio></td>')
            }
        });

    });
});
