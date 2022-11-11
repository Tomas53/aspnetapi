import React, {useState} from 'react'
import Constants from "../utilities/Constants"

export default function StockCreateTable(props){
    const initialData=Object.freeze({
        stockName:"Meta",
        country:"USA"
    })

    const [tableData, setTableData]=useState(initialData);


    const handleChange=(e)=>{
        setTableData({
            ...tableData,
            [e.target.name]:e.target.value,
        });
    }
    
   const handleSubmit=(e)=>{
        e.preventDefault();
        const stockToCreate={
            stockId:0,
            stockName:tableData.stockName,
            country:tableData.country

        };

        const url=Constants.API_URL_CREATE_STOCK;

            fetch(url, {
              method: 'POST',
              headers:{
                  'Content-Type':'application/json'
              },
              body:JSON.stringify(stockToCreate)
            })
              .then(response => response.json())
              .then(responseFromServer => {
                console.log(responseFromServer);
                
              })
              .catch((error) => {
                console.log(error);
                alert(error);
              });
              props.onStockCreated(stockToCreate);
          }
       
    
    return(
        <div>
            <form className="w-100 px-5">
                <h1 className="mt-5">Create new stock</h1>

                <div className='mt-5'>
                    <label className='h3 form-label'>Stock name</label>
                    <input value={tableData.stockName} name="stockName" type="text" className="form-control" onChange={handleChange}/>
                    

                </div>
                <div className='mt-4'>
                    <label className='h3 form-label'>Stock country</label>
                    <input value={tableData.country} name="country" type="text" className="form-control" onChange={handleChange}/>
                    

                </div>

                <button onClick={handleSubmit} className="btn btn-dark btn-lg w-100 mt-5">Submit</button>
                <button onClick={()=>props.onStockCreated(null)} className="btn btn-blue btn-lg w-100 mt-3">Cancel</button>

            </form>
        </div>
    )
}