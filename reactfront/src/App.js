import React, { useState } from 'react';
import Constants from "./utilities/Constants";
import StockCreateTable from './components/StockCreateTable';
import { Routes,Route, Link } from 'react-router-dom';


function App() {
  const [stocks, setStocks] = useState([]);
  const [showingCreateNewStockTable,setShowingCreateNewStockTable]=useState(false);
  function getStocks() {
    const url =Constants.API_URL_GET_ALL_STOCKS;
    fetch(url, {
      method: 'GET'
    })
      .then(response => response.json())
      .then(stocksFromServer => {
        console.log(stocksFromServer);
        setStocks(stocksFromServer);
      })
      .catch((error) => {
        console.log(error);
        alert(error);
      });
  }
  return (

    <div className="container">
      {/* <Routes>
        <Route path="new" element={StockCreateTable}/>
      </Routes> */}

      <div className="row min-vh-100">
        <div className="col d-flex flex-column justify-content-center align-items-center">
          {showingCreateNewStockTable===false&&(
            <div>
            <h1>hello</h1>
            {/* <Link to="new">create new stock</Link> */}
            <div className="mt-5">
              <button onClick={getStocks}className="btn btn-dark btn-lg w-100">Get stocks</button>
              <button onClick={()=>setShowingCreateNewStockTable(true)}className="btn btn-secondary btn-lg w-100 mt-4">create new stock</button>

            </div>
          </div>
          )}
          
          {(stocks.length>0&& showingCreateNewStockTable===false)&&renderStockTable()}
          {showingCreateNewStockTable&&<StockCreateTable onStockCreated={onStockCreated}/>}
        </div>

      </div>

    </div>
  );

  function renderStockTable() {
    return (
      <div className="table-responsive mt-6">
        <table className="table table-bordered border-blue">
          <thead>
            <tr>
              <th scope="col">StockId (PK)</th>
              <th scope="col">StockName </th>
              <th scope="col">StockCountry </th>
              <th scope="col">StockPrice </th>
              <th scope="col">StockData </th>
            </tr>
          </thead>
          <tbody>
            {
              stocks.map((stock)=>(
                <tr key={(stock.stockId)}>
                <th scope="row">{stock.stockId}</th>
                <td>{stock.stockName}</td>
                <td>{stock.country}</td>
                <td>
            
                </td>
  
              </tr>
              ))
            }

          </tbody>

        </table>
        <button onClick={()=>setStocks([])} className="btn btn-dark btn-lg w-100">empty list</button>
      </div>
    );
  }
  function onStockCreated(createdStock){
    setShowingCreateNewStockTable(false);
    if(createdStock===null){
      return;
    }

    alert('Stock created succsessfuly')

    getStocks();
  }

}

export default App;
