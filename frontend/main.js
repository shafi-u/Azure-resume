window.addEventListener('DOMContentLoaded', (event) =>{
    getVisitCount();
})
const functionApiUrl = 'https://fetchvisitorcounter.azurewebsites.net/api/FetchVisitorCounter?code=mSIhZWu_prH22lB2UwPrf_wEvLlD1ZeSYClt-pVdIkvcAzFuw8xP6w=='
const localfunctionApi = 'http://localhost:7071/api/FetchVisitorCounter';

const getVisitCount = () => {
    let count = 30;
    fetch(functionApiUrl).then(response => {
        return response.json()
    }).then(response =>{
        count = response.count;
        console.log("Website called function API.");
        document.getElementById("counter").innerText = count;   
    }).catch(function(error){
        console.log(error);
    });
    return count;
}

    