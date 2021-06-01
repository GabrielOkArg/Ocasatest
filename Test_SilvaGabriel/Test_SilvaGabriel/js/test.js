function test() {

    fetch('test.ashx', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'Accept': 'application/json'
        }
    }).then(function (res) {
        if (res.status ==200) {
            console.log("todo ok")
        }
    })
}