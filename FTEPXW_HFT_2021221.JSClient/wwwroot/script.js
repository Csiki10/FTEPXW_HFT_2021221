let directors = [];
let connection = null;

let diredctorIdToUpdate = -1;

const sleep = (ms) => {
    return new Promise((resolve, reject) => setTimeout(resolve, ms));
};
getdataSleep();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:44216/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("DirectorCreated", (user, message) => {
        getdata();
    });

    connection.on("DirectorDeleted", (user, message) => {
        getdata();
    });

    connection.on("DirectorUpdated", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    this.start();
    
}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getdata() {
    await fetch('http://localhost:44216/director')
        .then(x => x.json())
        .then(y => {
            directors = y;
            //console.log(actors);
            display();
        });
}

async function getdataSleep() {
    await
        sleep(5 * 1000)
            .then(() => {
                fetch('http://localhost:44216/director')
                    .then(x => x.json())
                    .then(y => {
                        directors = y;
                        //console.log(directors);
                        display();
                    });
            });
}  
    
function display() {
    document.getElementById('resultarea').innerHTML = "";
    directors.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.directorID + "</td><td>"
            + t.name + "</td><td>"
            + t.gender + "</td><td>"
            + t.age + "</td><td>"
        + `<button type="button" onclick="remove(${t.directorID})">Delete</button>`
        + `<button type="button" onclick="showupdate(${t.directorID})">Update</button>`
            + "</td></tr>";
    });
}

function showupdate(id) {
    document.getElementById('directornametoupdate').value = directors.find(t => t['directorID'] == id)['name'];
    document.getElementById('directoragetoupdate').value = directors.find(t => t['directorID'] == id)['age'];
    document.getElementById('directorgendertoupdate').value = directors.find(t => t['directorID'] == id)['gender'];
    document.getElementById('updateformdiv').style.display = 'flex';
    diredctorIdToUpdate = id;
}

function remove(id) {
    fetch('http://localhost:44216/director/' + id, {
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
    let id = 0;
    let name = document.getElementById('directorname').value;   
    let age = document.getElementById('directorage').value;
    let gender = document.getElementById('directorgender').value;

    fetch('http://localhost:44216/director', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { ID: id, Name: name, Age: age, Gender: gender, }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let name = document.getElementById('directornametoupdate').value;
    let age = document.getElementById('directoragetoupdate').value;
    let gender = document.getElementById('directorgendertoupdate').value;

    fetch('http://localhost:44216/director', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { DirectorID: diredctorIdToUpdate, Name: name, Age: age, Gender: gender, }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}