# WooliesX

This API contains the following end points:


Method: GET

Endpoint: https://wooliesxapi.azurewebsites.net/api/Exercise/exercise1/User
Returns user name with token:

        Example Response:
        {
            "passed": true,
            "url": "",
            "message": {
                "name": "Qasim",
                "token": "b674c919-a9aa-4669-af1e-ff6acfb88061"
            }
        }


Method: POST

Endpoint: https://wooliesxapi.azurewebsites.net/api/Exercise/exercise2/sort?sortOption=Recommended
This end point returns products in a sorted manner based on the sortOption passed in the querystring.

          Request body has to contain the right user token
          
          {
             "token": "b674c919-a9aa-4669-af1e-ff6acfb88061",
              "url": "https://wooliesxapi.azurewebsites.net/"
          }
          
          Following sort options are supported:
          
          "Low" - Low to High Price
          "High" - High to Low Price
          "Ascending" - A - Z sort on the Name
          "Descending" - Z - A sort on the Name
          "Recommended" - this will call the "shopperHistory" resource to get a list of customers orders and needs to return based on popularity
          
          Example Response:
          
          {
            "passed": true,
            "url": "https://wooliesxapi.azurewebsites.net/",
            "message": [
            {
                "name": "Test Product A",
                "price": 99.99,
                "quantity": 3
            },
            {
                "name": "Test Product B",
                "price": 101.99,
                "quantity": 1
            },
            {
                "name": "Test Product F",
                "price": 999999999999,
                "quantity": 1
            },
            {
                "name": "Test Product C",
                "price": 10.99,
                "quantity": 2
            }
          ]
        }
          
          
          
          
Method POST

Endpoint: https://wooliesxapi.azurewebsites.net/api/Exercise/exercise3/trolleyTotal
This endpoint returns the minimum possible total bill of the items in a trolley taking into consideration any applicable special offers.

Sample Request Body:

{
  "products": [
    {
      "name": "A",
      "price": 10
    },
    {
    	"name": "B",
    	"price": 5
    	
    }
  ],
  "specials": [
    {
      "quantities": [
        {
          "name": "A",
          "quantity": 3
        }
      ],
      "total": 6
    },
    {
      "quantities": [
        {
          "name": "B",
          "quantity": 4
        }
      ],
      "total": 3
    }
  ],
  "quantities": [
    {
      "name": "A",
      "quantity": 14
    },
    {
    "name": "B",
    "quantity": 5
    }
  ]
}

 


Sample Request Response:

52

      
