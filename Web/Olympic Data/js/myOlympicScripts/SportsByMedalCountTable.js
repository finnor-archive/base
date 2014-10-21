//Adrian Flannery

function getJSONOlympicData(dataJSON)
{    
    //sort data by sport    
    dataJSON.sort(function (a, b) {
        if (a.sport > b.sport) 
            return 1;
        if (a.sport < b.sport)
            return -1;
        return 0;
        });
    
    //data to populate table with
    var tableData = [];
    
    var numberOfSports = 0;    
    var athlete;
    var age;
    var sport;
    var total;
    
    //processes the data to detemine medals acieved by people between 22 and 29 and stores the medals and sport
    for(var i=0;i<dataJSON.length;i++)
    {
        athlete = dataJSON[i];
        age = athlete.age;
        sport = athlete.sport;
        // if in the right age
        if (age>=22 && age<=29)
        {
            total = athlete.bronzemedals + athlete.silvermedals + athlete.goldmedals;
            //if not initial case
            if (numberOfSports>0)
            {
                //if sport has already been seen, add to the sums
                if (tableData[numberOfSports-1].sport===sport)
                {
                    tableData[numberOfSports-1].bronzemedals += athlete.bronzemedals;
                    tableData[numberOfSports-1].silvermedals += athlete.silvermedals;
                    tableData[numberOfSports-1].goldmedals += athlete.goldmedals;
                    tableData[numberOfSports-1].totalmedals += total;
                }
                // else create new entry with sport and sums
                else
                {
                    tableData[numberOfSports] = {"sport": sport, "goldmedals": athlete.goldmedals, 
                            "silvermedals": athlete.silvermedals, "bronzemedals": athlete.bronzemedals,
                            "totalmedals": total};
                    numberOfSports++;    
                }
            }
            //else initial case, create first entry with sport and sums
            else
            {
                tableData[numberOfSports] = {"sport": sport, "goldmedals": athlete.goldmedals, 
                        "silvermedals": athlete.silvermedals, "bronzemedals": athlete.bronzemedals,
                        "totalmedals": total};
                numberOfSports++;    
            }
        }
    }


    //sort table by total medal count
    tableData.sort(function (a, b) {
        return b.totalmedals - a.totalmedals;
        });
  
    //Build Table Header
    var headerTable = ["Sport", "Gold Medals", "Silver Medals", "Bronze Medals", "Total Medals"];
    
    d3.select("thead").selectAll("th")
        .data(headerTable)
        .enter().append("th").text(function(d){return d});

    //Build Table
    //Build Rows
    var tr = d3.select("tbody").selectAll("tr")
        .data(tableData).enter().append("tr")
 
    //Populate Cells
    tr.selectAll("td")
        .data(function(d){return d3.values(d)})
        .enter().append("td")
        .text(function(d) {return d})  
}
   