/* 
    The selectQUery(query) function takes in a SQL query as a string, then
    perfrosm an Ajax call to the HomeController to query the database.
    Upon getting the SQL query results from the HomeController, the function
    parses the return data and creates a table of the returned tuples.

    This function requires the calling View page to have an element with the
    id 'data' to display the table that is created with the results of the query.
*/
function selectQuery(query) {
    $('#data').html("");
    $.ajax({
        url: "/Home/SelectQuery",
        type: "GET",
        datatype: "json",
        data: { query: query },
        success: function (data) {
            var response = JSON.parse(data);
            var headers = new Set();
            $('#data').append('<table style="border: 1px solid;" id="outputTable">');
            $.each(response, function (index, element) {
                $('#data').append('<tr>');
                $.each(element, function (i, e) {
                    $('#data').append('<td style="width: 110px;">' + e + '</td>');
                    headers.add(i);
                });
                $('#data').append('</tr>');
            });
            $('#data').append('</table>');

            // Create the header row in the table and insert at the top.
            var headerString = '<tr>'
            for (let header of headers) {
                headerString += '<th style="width: 110px">' + header + '</th>';
            }
            headerString += '</tr>';
            $('#outputTable').after(headerString);
            $('#outputTable').css("border","1px solid #000");
        },
        error: function () {

            alert("ERROR in SelectQuery");
        }
    });
}