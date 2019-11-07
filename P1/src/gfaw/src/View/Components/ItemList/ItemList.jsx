import { createItem } from '../../../Model/Item';
import React, { useState, useEffect } from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Title from '../Title/Title';
import Button from '@material-ui/core/Button';
import IconButton from '@material-ui/core/IconButton';
import EuroIcon from '@material-ui/icons/Euro';
import DeleteIcon from '@material-ui/icons/Delete';
import DeleteItem from '../DeleteItem/DeleteItem'

//Merely for demo
const rows = [
 createItem(0, 0, 'Sopa de pedra', 'Edifício H', '15h', '04/11/2019', '11/11/2019'),
 createItem(1, 1, 'Sopa de pedra', 'Edifício H', '15h', '04/11/2019', '11/11/2019'),
 createItem(2, 2, 'Sopa de pedra', 'Edifício H', '15h', '04/11/2019', '11/11/2019'),
 createItem(3, 3, 'Sopa de pedra', 'Edifício H', '15h', '04/11/2019', '11/11/2019'),
 createItem(4, 4, 'Sopa de pedra', 'Edifício H', '15h', '04/11/2019', '11/11/2019'),
];

const useStyles = makeStyles(theme => ({
 button: {
  margin: theme.spacing(1),
 },
}));

//Merely a demo function
function getItemQuantity() {
 //TODO: Retrieve an Item's quantity from the Inventory
 return Math.floor(Math.random() * 100);
}

export default function ItemList() {
 const classes = useStyles();

 const [items, setItems] = useState([]);

 // State keeping for the clicked Item
 const [selectedItem, setSelectedItem] = useState(-1);

 //DeleteItem's state
 const [showDeleteItem, toggleDeleteItem] = useState(false);

 const handleClickOpen = (itemID) => {
  toggleDeleteItem(true);
  setSelectedItem(itemID);
 };
 const handleClose = () => {
  toggleDeleteItem(false);
 };

 useEffect(() => {
  //TODO: Retrieve Meals from the API
  /*Example: var req = fetch(api_url/items);
  var reqObj = JSON.parse(req);
  for(reqObj.Meal in reqObj){
   setMeals(meals + {reqObj.description, ...})
  }
  */
  setItems(rows);
 }, []);
 return (
  <React.Fragment>
   {showDeleteItem ? <DeleteItem open={showDeleteItem} close={handleClose} itemID={selectedItem} /> : null}
   <Title>Items</Title>
   <Table size="small">
    <TableHead>
     <TableRow>
      <TableCell>Identification Number</TableCell>
      <TableCell>Label</TableCell>
      <TableCell>Location</TableCell>
      <TableCell>Remaining Available Time</TableCell>
      <TableCell>Production Date</TableCell>
      <TableCell>Expiration Date</TableCell>
      <TableCell>Quantity</TableCell>
      <TableCell align="center">Actions</TableCell>
     </TableRow>
    </TableHead>
    <TableBody>
     {items.map(row => (
      <TableRow key={row.id}>
       <TableCell>{row.identificationNumber}</TableCell>
       <TableCell>{row.label}</TableCell>
       <TableCell>{row.location}</TableCell>
       <TableCell>{row.timePeriod}</TableCell>
       <TableCell>{row.productionDate}</TableCell>
       <TableCell>{row.expirationDate}</TableCell>
       <TableCell>{getItemQuantity()}</TableCell>
       <TableCell align="center">
        <IconButton aria-label="delete" className={classes.margin} onClick={function(event) { handleClickOpen(row.id) }}>
         <DeleteIcon fontSize="small" />
        </IconButton>
        <IconButton aria-label="euro" className={classes.margin}>
         <EuroIcon fontSize="small" />
        </IconButton>
       </TableCell>
      </TableRow>
     ))}
    </TableBody>
   </Table>
   <div>
    <Button variant="contained" color="primary" className={classes.button}>
     Create Item
    </Button>
   </div>
  </React.Fragment>
 );
}