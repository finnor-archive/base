//Adrian Flannery

function getJSONOlympicData(dataJSON)
{
    //sort data by country
    dataJSON.sort(function (a, b) {
        if (a.country > b.country) 
            return 1;
        if (a.country < b.country)
            return -1;
        return 0;
        });
        
    
    //data that wil populate pie chart
    var pieData = [];  
    
    var numberOfCountries = 0; 
    var athlete;
    var country;
    var total;
    
    //processes the data to determine countries and their medals
    for(var i=0;i<dataJSON.length;i++)
    {
        athlete = dataJSON[i];
        country = athlete.country;
        total = athlete.bronzemedals + athlete.silvermedals + athlete.goldmedals;
        //if not initial case
        if (numberOfCountries>0)
        {
            //if country has already been seen, add it to sum
            if (pieData[numberOfCountries-1].country===country)
                pieData[numberOfCountries-1].medals += total;
            // else create new country and new sum
            else
            {
                pieData[numberOfCountries] = {"country": country, "medals": total};
                numberOfCountries++;
            }
        }
        //else initial case, create initial entry
        else
        {
            pieData[numberOfCountries] = {"country": country, "medals": total};
            numberOfCountries++;
        }
    }



    //data is sorted by order of medals
    pieData.sort(function (a, b) {
        return a.medals - b.medals;
        });


    //constants    
    var WIDTH = 1000,
        HEIGHT = 700,
        RADIUS = Math.min(WIDTH, HEIGHT) / 2;

    //create graph
    var svg = d3.select(".chart").append("svg")
        .attr("width", WIDTH)
        .attr("height", HEIGHT)
        .append("g")
            .attr("transform", "translate(" + WIDTH / 2 + "," + HEIGHT / 2 + ")");

    //create tooltip
    var div = d3.select(".chart").append("div")   
        .attr("class", "tooltip")               
        .style("opacity", 0);

    //color scale
    var color = d3.scale.category20();


    var arc = d3.svg.arc()
        .outerRadius(RADIUS - 10)
        .innerRadius(0);

    var pie = d3.layout.pie()
        .value(function(d) { return d.medals; });

    //create sections
    var g = svg.selectAll(".arc")
        .data(pie(pieData))
        .enter().append("g")
            .attr("class", "arc");

    g.append("path")
        .attr("d", arc)
        .attr("fill", function(d, i) {return color(i);});


/*  Optional Code to Place a Text Label on Larger Countries
  g.append("text")
      .attr("transform", function(d) { return "translate(" + arc.centroid(d) + ")"; })
      .attr("dy", ".35em")
      .style("text-anchor", "middle")
      .text(function(d, i) { 
          if (pieData[i].medals<70)
                return "";
          else
                return pieData[i].country; 
        });
*/
   
    g.data(pieData)
    //tooltip on hover 
    g.on("mouseover", function(d) {
        div.style("width", "200px");
        div.transition()        
            .duration(200)      
            .style("opacity", .9);      
        div .html("Country: "  + d.country + "<br/>Medals: " + d.medals)  
            .style("left", (d3.event.pageX) + "px")     
            .style("top", (d3.event.pageY - 28) + "px");    
        })                  
      .on("mouseout", function(d) {       
        div.transition()        
            .duration(500)      
            .style("opacity", 0)}) 
    //build list of athletes on click
    g.on("click", function(d) {
        var listOfAthletes = [];
        d3.selectAll("#myNode").remove();
        for(var j=0;j<dataJSON.length;j++)
            if (dataJSON[j].country===d.country)
                    listOfAthletes[listOfAthletes.length] = dataJSON[j]; 
        d3.select("list").data(listOfAthletes).enter().append("p")
            .text(function (d){
                return ("Name: " + d.athlete 
                    + " | Age: " + d.age 
                    + " | Country: " + d.country 
                    + " | Year: " + d.year 
                    + " | Sport: " + d.sport 
                    + "  | Gold Medals: " + d.goldmedals
                    + "  | Silver Medals: " + d.silvermedals
                    + "  | Bronze Medals: " + d.bronzemedals);
                })
                .attr("id", "myNode")
                .style("text-indent", "50px")
        });
}