var uri = 'https://api.spoonacular.com/recipes/complexSearch'
const APIKEY = 'aba2b591b71b429e8dc8a2d250f78e90'
var max_carbs, max_pro, max_cals, max_fat, main_ingredient, number
var params = ''

const btnGetRecipes = document.getElementById('get_recipes')
    .addEventListener('click', function() {
        getRecipes()
    })

function getRecipes() {
    clearResponse()

    max_carbs = document.getElementById('max_carbs').value
    max_pro = document.getElementById('max_pro').value
    max_cals = document.getElementById('max_cals').value
    max_fat = document.getElementById('max_fat').value
    main_ingredient = document.getElementById('main_ingredient').value
    if (main_ingredient.length <= 0) {
        return;
    }

    number = document.getElementById('number').value
    AJAXrequest()

    resetVar()
}

function clearResponse() {
    document.getElementById('response').innerHTML = ''
}

function AJAXrequest() {
    getParams()
    var xhr = new XMLHttpRequest()
    xhr.open(
        'GET',
        uri + params,
        true
    )

    xhr.onreadystatechange = function() {
        if (xhr.readyState == 4 && xhr.status == 200) {
            showRecipes(xhr.responseText)
        }
    }

    xhr.send()
}

function getParams() {
    params += `?apiKey=${APIKEY}`
    params += `&query=${main_ingredient}`
    params += `&number=${number}`

    if (max_carbs != 0) {
        params += `&maxCarbs=${max_carbs}`
    }

    if (max_pro != 0) {
        params += `&maxProtein=${max_pro}`
    }

    if (max_cals != 0) {
        params += `&maxCalories=${max_cals}`
    }

    if (max_fat != 0) {
        params += `&maxFat=${max_fat}`
    }
}

function showRecipes(json) {
    var response = JSON.parse(json)
    response.results.forEach(element => {
        var title = document.createElement('h2')
        title.append(element.title)

        var image = document.createElement('img')
        image.src = element.image
        
        var nutrientsList = document.createElement('ul')

        element.nutrition.nutrients.forEach(nutrient => {
            // creo l'oggetto
            var li = document.createElement('li')
            li.append(`${nutrient.name} -> ${Math.round(parseFloat(nutrient.amount))} ${nutrient.unit}`)
            // collego l'oggeto alla lista
            nutrientsList.appendChild(li)
        });

        document.getElementById('response').appendChild(title)
        document.getElementById('response').appendChild(image)
        document.getElementById('response').appendChild(nutrientsList)
        document.getElementById('response').appendChild(document.createElement('hr'))
    });
}

function resetVar() {
    params = ''
    max_cals = ''
    max_carbs = ''
    max_pro = ''
    max_fat = ''
    main_ingredient = ''
    number = ''
}