// A simple templating method for replacing placeholders enclosed in curly braces.
if (!String.prototype.supplant) {
    String.prototype.supplant = function (o) {
        return this.replace(/{([^{}]*)}/g,
            function (a, b) {
                var r = o[b];
                return typeof r === 'string' || typeof r === 'number' ? r : a;
            }
        );
    };
}

//https://www.telerik.com/forums/signalr-with-sorting-create-destroy-or-update
$(function () {
    var results = $.connection.resultsHub,

        $resultsTable = $('#resultsTable'),
        $resultsTableBody = $resultsTable.find('tbody'),
        rowTemplate = '<tr data-symbol="{CandidateID}"><td>{FName}</td><td>{LName}</td><td>{PartyName}</td><td>{Seat}</td><td>{VoteCount}</td></tr>',
        $voteTickerUl = $('#voterTicker').find('ul'),// the generated client-side hub proxy
        liTemplate = '<li data-symbol="{CandidateID}"><span class="symbol">{LName}, {FName}</span><span class="votes"> {VoteCount}</span></li>';
    function formatCandidate(candidate) {
        return $.extend(candidate, {
            CandidateID: candidate.CandidateID,
            FName: candidate.FName,
            LName: candidate.LName,
            PartyName: candidate.PartyName,
            Seat: candidate.Seat,
            VoteCount: candidate.VoteCount
        });
    }

    function init() {
        results.server.getAllCandidates().done(function (candidates) {
            $resultsTableBody.empty();
            $voteTickerUl.empty();
            $.each(candidates, function () {
                var candidate = formatCandidate(this);
                $resultsTableBody.append(rowTemplate.supplant(candidate));
                $voteTickerUl.append(liTemplate.supplant(candidate));
            });
        });
    }

    // Add a client-side hub method that the server will call
    results.client.updateResult = function (candidate) {
        var displayCandidate = formatCandidate(candidate),
            $row = $(rowTemplate.supplant(displayCandidate)),
            $li = $(liTemplate.supplant(displayCandidate));

        $resultsTableBody.find('tr[data-symbol=' + candidate.CandidateID + ']')
            .replaceWith($row);
        $voteTickerUl.find('li[data-symbol=' + candidate.CandidateID + ']')
            .replaceWith($li);
    };

    $.connection.hub.logging = true;
    $.connection.hub.error(function (error) {
        console.log('SignalR Error: ' + error);
    });

    // Start the connection
    $.connection.hub.start().done(init);


});

function scrollTicker() {
    var w = $voteTickerUl.width();
    $voteTickerUl.css({ marginLeft: w });
    $voteTickerUl.animate({ marginLeft: -w }, 15000, 'linear', scrollTicker);
}
