const API_BASE_URL_DEVELOPEMENT='https://localhost:7170';

const ENDPOINTS={
    GET_ALL_STOCKS: 'get-all-stocks',
    GET_STOCK_BY_ID:'get-stock-by-id',
    CREATE_STOCK:'create-stock',
    UPDATE_STOCK:'update-stock',
    DELETE_STOCK_BY_ID:'delete-stock-by-id'
}

const development={
    API_URL_GET_ALL_STOCKS:`${API_BASE_URL_DEVELOPEMENT}/${ENDPOINTS.GET_ALL_STOCKS}`,
    API_URL_GET_STOCK_BY_ID:`${API_BASE_URL_DEVELOPEMENT}/${ENDPOINTS.GET_STOCK_BY_ID}`,
    API_URL_CREATE_STOCK:`${API_BASE_URL_DEVELOPEMENT}/${ENDPOINTS.CREATE_STOCK}`,
    API_URL_UPDATE_STOCK:`${API_BASE_URL_DEVELOPEMENT}/${ENDPOINTS.UPDATE_STOCK}`,
    API_URL_DELETE_STOCK_BY_ID:`${API_BASE_URL_DEVELOPEMENT}/${ENDPOINTS.DELETE_STOCK_BY_ID}`,
}

const production={

};

const Constants=process.env.NODE_ENV==='development'?development:production;
export default Constants;