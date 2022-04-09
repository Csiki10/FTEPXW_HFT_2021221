let directors = [];

fetch('http://localhost:44216/director')
    .then(x => x.json())
    .then(y => {
        directors = y;
        console.log(directors);
        display();
    });

function display() {
    directors.forEach(d => {       
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>"
            + d.directorID + "</td><td>"
            + d.name + "</td><td>"
            + d.gender + "</td><td>"
            + d.age + "</td><td>"
        + `<button type="button" onclick="remove(${d.directorID})">Delete</button>`
            + "</td></tr>";
    });
}