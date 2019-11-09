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
import DeleteItem from '../DeleteItem/DeleteItem';
import PurchaseItem from '../PurchaseItem/PurchaseItem';
import CreateItem from '../CreateItem/CreateItem';
import { getData } from '../../../Controller/GetController';

const useStyles = makeStyles(theme => ({
  button: {
    margin: theme.spacing(1),
  },
}));

export default function ItemList() {
  const classes = useStyles();

  const [items, setItems] = useState([]);

  // State keeping for the clicked Item
  const [selectedItem, setSelectedItem] = useState(-1);

  //DeleteItem's state
  const [showDeleteItem, toggleDeleteItem] = useState(false);

  const handleOpenRemoveItem = (itemID) => {
    toggleDeleteItem(true);
    setSelectedItem(itemID);
  };
  const handleCloseRemoveItem = () => {
    toggleDeleteItem(false);
  };

  //PurchaseItem's state
  const [showPurchaseItem, togglePurchaseItem] = useState(false);

  const handleOpenPurchaseItem = (itemID) => {
    togglePurchaseItem(true);
    setSelectedItem(itemID);
  };
  const handleClosePurchaseItem = () => {
    togglePurchaseItem(false);
  };

  //CreateItem's state
  const [showCreateItem, toggleCreateItem] = useState(false);

  const handleOpenCreateItem = () => {
    toggleCreateItem(true);
  };
  const handleCloseCreateItem = () => {
    toggleCreateItem(false);
  };

  useEffect(() => {
    var items = getData('items');
    var rows = [];
    items.then((data) => {
      for (var i = 0; i < data.length; i++) {
        var item = data[i];
        var newItem = createItem(item.id, 0, item.mealId, item.location, item.availableToServeUntil, item.productionDate, item.expirationDate);
        rows.push(newItem);
      }
    }).then(() => { setItems(rows); })
  }, []);

  return (
    <React.Fragment>
      {showDeleteItem ? <DeleteItem open={showDeleteItem} close={handleCloseRemoveItem} itemID={selectedItem} /> : null}
      {showPurchaseItem ? <PurchaseItem open={showPurchaseItem} close={handleClosePurchaseItem} itemID={selectedItem} /> : null}
      {showCreateItem ? <CreateItem open={showCreateItem} close={handleCloseCreateItem} /> : null}
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
              <TableCell align="center">
                <IconButton aria-label="delete" className={classes.margin} onClick={function (event) { handleOpenRemoveItem(row.id) }}>
                  <DeleteIcon fontSize="small" />
                </IconButton>
                <IconButton aria-label="euro" className={classes.margin} onClick={function (event) { handleOpenPurchaseItem(row.id) }}>
                  <EuroIcon fontSize="small" />
                </IconButton>
              </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
      <div>
        <Button variant="contained" color="primary" className={classes.button} onClick={handleOpenCreateItem}>
          Create Item
    </Button>
      </div>
    </React.Fragment>
  );
}