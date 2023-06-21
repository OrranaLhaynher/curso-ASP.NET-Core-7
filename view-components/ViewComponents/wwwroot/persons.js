document.querySelector("#load-persons-list").addEventListener("click",
    async function () {
        var response = await fetch("load-persons-list", { method: "GET" });
        var responseBody = await response.text();
        document.querySelector("#list").innerHTML = responseBody;
});