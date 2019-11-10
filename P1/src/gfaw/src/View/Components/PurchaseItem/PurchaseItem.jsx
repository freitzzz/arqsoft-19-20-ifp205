import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Button from '@material-ui/core/Button';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogContentText from '@material-ui/core/DialogContentText';
import DialogTitle from '@material-ui/core/DialogTitle';
import InputLabel from '@material-ui/core/InputLabel';
import MenuItem from '@material-ui/core/MenuItem';
import FormControl from '@material-ui/core/FormControl';
import Select from '@material-ui/core/Select';
import { deleteWithParameterData } from '../../../Controller/DeleteController';


const useStyles = makeStyles(theme => ({
    formControl: {
        margin: "auto",
        width: "50%",
    },
    selectEmpty: {
        marginTop: theme.spacing(2),
    },
}));

export default function AlertDialog(props) {
    const classes = useStyles();
    const [buyerType, setBuyerType] = React.useState('');

    const handleChange = event => {
        setBuyerType(event.target.value);
    };

    const handleDeleteItem = () => {
        deleteWithParameterData('items', props.itemID, buyerType);
      };

    return (
        <div>
            <Dialog
                open={props.open}
                onClose={props.close}
                aria-labelledby="alert-dialog-title"
                aria-describedby="alert-dialog-description"
            >
                <DialogTitle id="alert-dialog-title">{"Register Item purchase"}</DialogTitle>
                <DialogContent>
                    <DialogContentText id="alert-dialog-description">
                        Select the buyer's User Type:
     </DialogContentText>
                </DialogContent>
                <FormControl className={classes.formControl}>
                    <InputLabel id="demo-simple-select-label">User Type</InputLabel>
                    <Select
                        labelId="demo-simple-select-label"
                        id="demo-simple-select"
                        value={buyerType}
                        onChange={handleChange}
                    >
                        <MenuItem value={'internal'}>Internal</MenuItem>
                        <MenuItem value={'external'}>External</MenuItem>
                        <MenuItem value={'administrator'}>Administrator</MenuItem>
                        <MenuItem value={'kitchen%20worker'}>Kitchen Worker</MenuItem>
                    </Select>
                </FormControl>
                <DialogContent>
                    <DialogActions>
                        <Button onClick={props.close} color="primary">
                            Cancel
          </Button>
                        <Button onClick={() => { handleDeleteItem(); props.close(); }} color="primary" autoFocus>
                            Confirm
          </Button>
                    </DialogActions>
                </DialogContent>
            </Dialog>
        </div>
    );
}