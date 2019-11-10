import React from 'react';
import Button from '@material-ui/core/Button';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogTitle from '@material-ui/core/DialogTitle';
import { deleteData } from '../../../Controller/DeleteController';


export default function AlertDialog(props) {

  const handleDeleteItem = () => {
    deleteData('items', props.itemID);
  };

  return (
    <div>
      <Dialog
        open={props.open}
        onClose={props.close}
        aria-labelledby="alert-dialog-title"
        aria-describedby="alert-dialog-description"
      >
        <DialogTitle id="alert-dialog-title">{"Are you sure you want to remove this Item ?"}</DialogTitle>
        <DialogActions>
          <Button onClick={props.close} color="primary">
            Cancel
          </Button>
          <Button onClick={() => { handleDeleteItem(); props.close();}} color="primary" autoFocus>
            Delete
          </Button>
        </DialogActions>
      </Dialog>
    </div>
  );
}