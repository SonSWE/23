function validator(options){
    var formElement = document.querySelector(options.form)
    // ham kiem tra phan tu cha
    function getParentElement(inputElement,selector){
        while(inputElement.parentElement){
            if(inputElement.parentElement.matches(selector)){
               return inputElement.parentElement 
            }
            inputElement = inputElement.parentElement
        }

    }
    // ham kiem tra da dien vao input chua
    function validate(value,inputElement,parentElement){
        var errorElement = value.test(inputElement.value)
        if(errorElement){
              inputElement.classList.add('invalid')
              parentElement.querySelector('.form-label').classList.add('valid')
              parentElement.querySelector('.form-message').innerHTML = errorElement
           }
        else{
            parentElement.querySelector('.form-message').innerHTML = "";
            inputElement.classList.remove('invalid')
            parentElement.querySelector('.form-label').classList.remove('valid')
            parentElement.querySelector('.form-label').style.color = '#888'
        }
        return errorElement;
    }
    // khi blur vao input
    options.values.forEach(function(value){
        var inputElement = formElement.querySelector(value.selector)
        var parentElement = getParentElement(inputElement,'.form-group')
        inputElement.onblur = function(){           
            validate(value,inputElement,parentElement)          
          
        };
        inputElement.oninput = function(){
            inputElement.classList.remove('invalid')
            parentElement.querySelector('.form-label').classList.remove('valid')
            parentElement.querySelector('.form-message').innerHTML = "";
        }

    }); 

}
validator.isRequired = function(selector){
    return {
        selector: selector,
        test: function(item){
            return item.trim() ? undefined : 'vui lòng nhập hàng này'
        }
    }
}
validator({
    form: '.form-1',
    values:[
        validator.isRequired('#fullname'),
        validator.isRequired('#password')
    ]
    
})