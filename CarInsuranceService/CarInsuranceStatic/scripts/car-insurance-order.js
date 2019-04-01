(() => {
    const carModels = {

        populate: (models) => {
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
                items.push(`<option value="1">${normalizedName.join(' ')}</option>`)
            }
            $('#car-models')
                .html('')
                .html(items.join('\n'))
                .selectpicker('refresh')
        },

        filter: (brandID) => {
            let models

            $.ajax('/api/insurance/cars/brands/' + brandID, { cache: false })
                .done((models) => {
                    carModels.populate(models)

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
    }


    $(document).ready(() => {
        $.fn.selectpicker.Constructor.DEFAULTS = {
            ...$.fn.selectpicker.Constructor.DEFAULTS,
            noneResultsText : 'Nenhum resultado encontrado'
        }
            
        $('#car-brands').change((value) => {
            const selectedBrand = $('#car-brands').val()
            if (!selectedBrand)
                return

            carModels.filter(selectedBrand)
        })

        $.ajax('/api/insurance/cars/brands')
            .done((brands) => {
                brands.sort((x, y) => {
                    if (x.Name < y.Name) return -1
                    if (x.Name > y.Name) return 1
                    return 0
                })

                let items = []
                for (brand of brands) {
                    let normalizedName = brand.Name.slice(0, 1).toUpperCase() + brand.Name.slice(1).toLowerCase()
                    items.push(`<option value="${brand.BrandID}">${normalizedName}</option>`)
                }
                $('#car-brands').append(items.join('\n'))
            })
    })

})()

