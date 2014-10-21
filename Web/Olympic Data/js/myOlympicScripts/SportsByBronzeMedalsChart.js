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
        
    
    //x-axis data
    var sports = [];
    //y-axis data
    var bronzeMedals = [];   
    
    var numberOfSports = 0; 
    var athlete;
    var sport;
    
    //processes the data to determine sports and their bronze medals
    for(var i=0;i<dataJSON.length;i++)
    {
        athlete = dataJSON[i];
        sport = athlete.sport;
        
        //if not initial case
        if (numberOfSports>0)
        {
            //if sport has already been seen, add it to sum
            if (sports[numberOfSports-1]===sport)
                bronzeMedals[numberOfSports-1] += athlete.bronzemedals;
            // else create new sport and new sum
            else
            {
                sports[numberOfSports] = sport;
                bronzeMedals[numberOfSports] = athlete.bronzemedals;
                numberOfSports++;
            }
        }
        //else initial case, create initial entry
        else
        {
            sports[numberOfSports] = sport;
            bronzeMedals[numberOfSports] = athlete.bronzemedals;
            numberOfSports++;
        }
    }
      

            


            
    //create graph
    var svg = d3.select(".chart").append("svg").attr("width", "900").attr("height", "650");
   
   //constants
    var GRAPHHEIGHT = 400;
    var PADDINGLEFT = 50; 
    var PADDINGTOP = 30;
    var BARWIDTH = 20;
    var BARMARGIN = 3;
    var MAXVALUEY = 70;    
    var DRAWXDISTANCE = BARWIDTH + BARMARGIN;
    var BARYMULT = GRAPHHEIGHT / MAXVALUEY;
    var ENDOFGRAPH = BARMARGIN*33 + BARWIDTH*32 + PADDINGLEFT;
    var MARGINFROMTOP = GRAPHHEIGHT + PADDINGTOP;
   
    var chartArea = svg.selectAll("rect").data(bronzeMedals).enter();
  
    //create tooltip
    var div = d3.select(".chart").append("div")   
        .attr("class", "tooltip")               
        .style("opacity", 0);
   
   
    //Draw the bars.
    chartArea.append("rect").attr("x", function(d, i)
            {
                return i * DRAWXDISTANCE + PADDINGLEFT + BARMARGIN;
            })
        .attr("y", function(d)
            {   
                return GRAPHHEIGHT + PADDINGTOP - (d * BARYMULT);
            })
        .attr("width", function(d)
            {
                return BARWIDTH;
            })
        .attr("height", function(d)
            {
                return d * BARYMULT;
            })
    //tooltip on hover        
        .on("mouseover", function(d) {      
            div.transition()        
                .duration(200)      
                .style("opacity", .9);      
            div .html("Bronze Medals: <br/>"  + d)  
                .style("left", (d3.event.pageX) + "px")     
                .style("top", (d3.event.pageY - 28) + "px");    
            })                  
        .on("mouseout", function(d) {       
            div.transition()        
                .duration(500)      
                .style("opacity", 0)}) 
    //builds list on click
        .on("click", function(d, i) {
            var listOfAthletes = [];
            d3.selectAll("#myNode").remove();
            for(var j=0;j<dataJSON.length;j++){
                if (dataJSON[j].sport===sports[i])
                {
                    if (dataJSON[j].bronzemedals>0)
                        listOfAthletes[listOfAthletes.length] = dataJSON[j]; 
                }
            }
            d3.select("list").data(listOfAthletes).enter().append("p")
                .text(function (d)
                    {
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
                .style("text-indent", PADDINGLEFT + "px")
        });
            
   
   //build x-axis ticks and labels
    var x = d3.scale.ordinal()
        .domain(sports)
        .rangeBands([PADDINGLEFT + 3, ENDOFGRAPH]);

    var xAxis = d3.svg.axis()
        .scale(x);

    svg.append("g")
        .attr("class", "x axis")
        .attr("transform", "translate(0," + MARGINFROMTOP + ")")
        .call(xAxis)
        .selectAll("text")
            .attr("y", 0)
            .attr("x", 20)
            .attr("dy", ".35em")
            .attr("transform", "rotate(90)")
            .style("text-anchor", "start")
            .attr("font-size", "15px")
   
   
   
   //build y axis line and labels
    var y = d3.scale.linear()
        .domain([MAXVALUEY, 0])
        .range([PADDINGTOP, GRAPHHEIGHT + PADDINGTOP]);

    var yAxis = d3.svg.axis()
        .scale(y)
        .orient("left");


    svg.append("g")
        .attr("class", "y axis")
        .attr("transform", "translate(" + PADDINGLEFT + ", 0)")
        .call(yAxis)
        .append("text")
            .attr("transform", "rotate(-90 0,50)")
            .attr("y", 6)
            .attr("dy", ".71em")
            .style("text-anchor", "end")
            .attr("font-size", "20px")
            .text("Number of Bronze Medals");
    }
