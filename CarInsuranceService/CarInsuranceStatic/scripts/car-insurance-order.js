(() => {
    const carBrands = {

        retrieve: async () => {
            const brands = await $.when($.ajax('/api/insurance/cars/brands'))
            brands.sort((x, y) => {
                if (x.Name < y.Name) return -1
                if (x.Name > y.Name) return +1
                return 0
            })

            let items = []
            for (brand of brands) {
                let normalizedName = brand.Name.slice(0, 1).toUpperCase() + brand.Name.slice(1).toLowerCase()
                items.push( { BrandID : brand.BrandID, Name : normalizedName } )
            }

            return items
        }
    }

    const carModels = {

        filter: async (brandID) => {
            const models = await $.when($.ajax('/api/insurance/cars/brands/' + brandID, { cache: false }))
       
            models.sort()

            let items = []
            for (model of models) {
                normalizedName = []
                let words = model.split(' ').filter(item => (item.length > 0))
                for (word of words) {
                    word = word.toUpperCase()
                    if (word.length > 3) word = word.slice(0, 1).toUpperCase() + word.slice(1).toLowerCase()
                    normalizedName.push(word)
                }
                items.push(normalizedName.join(' '))
            }

            return items
        }
    }

    async function Ready() {
        $.fn.selectpicker.Constructor.DEFAULTS = {
            ...$.fn.selectpicker.Constructor.DEFAULTS,
            noneResultsText: 'Nenhum resultado encontrado'
        }

        const brands = await carBrands.retrieve()
        $('#car-brands')
            .append(brands.map( (brand) => `<option value="${brand.BrandID}">${brand.Name}</option>` ).join('\n'))
            .selectpicker('refresh')
            .change(async (value) => {
                const selectedBrand = $('#car-brands').val()
                if (!selectedBrand)
                    return

                models = await carModels.filter(selectedBrand)
                $('#car-models')
                    .html('')
                    .html(models
                        .map((model) => `<option>${model}</option>`)
                        .join('\n'))
                    .selectpicker('refresh')

                const element = $('[data-id="car-models"]')
                if ((element.length)) {
                    const dropdown = element.siblings('.dropdown-menu')
                    if (dropdown.is(':hidden')) {
                        element.dropdown('toggle')
                        dropdown.find('input').val('').focus()
                    }
                }
            })
    }

    $(document).ready(() => (Ready()))
    //$(document).ready(Ready)
})()

