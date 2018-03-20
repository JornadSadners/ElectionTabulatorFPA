// A simple templating method for replacing placeholders enclosed in curly braces. from microsoft stockticker tutorial
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
function filterCandidates(event) {
    btn = event.target;
    filter = btn.id.toUpperCase();
    table = document.getElementById("results");
    tr = table.getElementsByTagName("tr");
    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[3];
        if (td) {
            if (td.innerHTML.toUpperCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}
$(function () {
    var results = $.connection.resultsHub,

        $resultsTable = $('#resultsTable'),
        $resultsTableBody = $resultsTable.find('tbody'),
        rowTemplate = '<tr data-symbol="{CandidateID}"><td>{FName}</td><td>{LName}</td><td>{PartyName}</td><td>{Seat}</td><td>{VoteCount}</td></tr>';
    //$voteTickerUl = $('#voteTicker').find('ul'),
    //liTemplate = '<li data-symbol="{CandidateID}"><span class="symbol">{LName}, {FName}</span><span class="votes"> {VoteCount}</span></li>';
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
            //$voteTickerUl.empty();
            $.each(candidates, function () {
                var candidate = formatCandidate(this);
                $resultsTableBody.append(rowTemplate.supplant(candidate));
                //$voteTickerUl.append(liTemplate.supplant(candidate));
            });
        });

    }

    results.client.updateResults = function (candidates) {
        $resultsTableBody.empty();
        $.each(candidates, function () {
            var candidate = formatCandidate(this),
                $row = $(rowTemplate.supplant(candidate));

            $resultsTableBody.append($row);
        });
    };
    $.connection.hub.logging = true;
    $.connection.hub.error(function (error) {
        console.log('SignalR Error: ' + error);
    });

    // Start the connection
    $.connection.hub.start().done(init);
});