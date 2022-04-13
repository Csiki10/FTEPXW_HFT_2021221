let directors = [];
let connection = null;
const sleep = (ms) => {
    return new Promise((resolve, reject) => setTimeout(resolve, ms));
};

getdataSleep();

;



async function getdata() {
    await fetch('http://localhost:44216/director')
        .then(x => x.json())
        .then(y => {
            actors = y;
            console.log(actors);
            display();
        });
}


async function getdataSleep() {
    await
        sleep(8 * 1000)
            .then(() => {
                fetch('http://localhost:44216/director')
                    .then(x => x.json())
                    .then(y => {
                        directors = y;
                        console.log(directors);
                        display();
                    });
            });
}
    
/*
if (directors.length != 0) {
    fetch('http://localhost:44216/director')
        .then(x => x.json())
        .then(y => {
            directors = y;
            console.log(directors);
            display();
        });
}
else {
    sleep(6 * 1000)
        .then(() => {
            fetch('http://localhost:44216/director')
                .then(x => x.json())
                .then(y => {
                    directors = y;
                    console.log(directors);
                    display();
                });
        });
}*/
    
function display() {
    document.getElementById('resultarea').innerHTML = "";
    directors.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.directorID + "</td><td>"
            + t.name + "</td><td>"
            + t.gender + "</td><td>"
            + t.age + "</td><td>"
        + `<button type="button" onclick="remove(${t.directorID})">Delete</button>`
            + "</td></tr>";
    });
}

function remove(id) {
    fetch('Access-Control-Allow-Origin: *' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null})
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function create() {
    let name = document.getElementById('directorname').value;
    let gender = document.getElementById('directorgender').value;
    let age = document.getElementById('directorage').value;

    fetch('Access-Control-Allow-Origin: *', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { actorName: name, actorAge: age, actorGender: gender, }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}