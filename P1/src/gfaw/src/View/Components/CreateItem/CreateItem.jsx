import React, { useEffect } from 'react';
import Button from '@material-ui/core/Button';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogTitle from '@material-ui/core/DialogTitle';
import { makeStyles } from '@material-ui/core/styles';
import InputLabel from '@material-ui/core/InputLabel';
import MenuItem from '@material-ui/core/MenuItem';
import FormControl from '@material-ui/core/FormControl';
import Select from '@material-ui/core/Select';
import TextField from '@material-ui/core/TextField';
import Input from '@material-ui/core/Input';
import { getIngredients } from '../../../Controller/IngredientsController';

const useStyles = makeStyles(theme => ({
    formControl: {
        margin: theme.spacing(1),
        minWidth: 120,
    },
    selectEmpty: {
        marginTop: theme.spacing(2),
    },
}));

export default function AlertDialog(props) {
    const classes = useStyles();

    //Selected Meal to serve as the base for the Item to be created
    const [baseMeal, setBaseMeal] = React.useState('');

    const handleMealChange = event => {
        setBaseMeal(event.target.value);
    };

    //Selected Location state
    const [selectedLocation, setSelectedLocation] = React.useState('ISEP');

    const handleLocationChange = event => {
        setSelectedLocation(event.target.value);
    };

    //Production Date state
    const [selectedProdDate, setSelectedProdDate] = React.useState();

    const handleProdDateChange = event => {
        setSelectedProdDate(event.target.value);
        console.log(event.target.value);
    };

    //Expiration Date state
    const [selectedExpDate, setSelectedExpDate] = React.useState();

    const handleExpDateChange = event => {
        setSelectedExpDate(event.target.value);
    };

    useEffect(() => {
        /*
        var ingredients = getIngredients();
        ingredients.then((data) => {
            console.log(data);
        })
        */
       }, []);

    return (
        <div>
            <Dialog
                open={props.open}
                onClose={props.close}
                aria-labelledby="alert-dialog-title"
                aria-describedby="alert-dialog-description"
            >
                <DialogTitle id="alert-dialog-title">{"Add a new Item to the Inventory"}</DialogTitle>
                <DialogContent>
                    <FormControl className={classes.formControl}>
                        <InputLabel id="demo-simple-select-label">Meals</InputLabel>
                        <Select
                            labelId="demo-simple-select-label"
                            id="demo-simple-select"
                            value={baseMeal}
                            onChange={handleMealChange}
                        >
                            <MenuItem value={'meal1'}>Sopa de Pedra</MenuItem>
                            <MenuItem value={'meal2'}>Frango</MenuItem>
                        </Select>
                    </FormControl>
                    <FormControl className={classes.formControl}>
                        <InputLabel htmlFor="component-simple">Location</InputLabel>
                        <Input id="component-simple" value={selectedLocation} onChange={handleLocationChange} />
                    </FormControl>
                </DialogContent>
                <DialogContent>
                    <form className={classes.container} noValidate>
                        <TextField
                            id="prodDate"
                            label="Production Date"
                            type="date"
                            className={classes.textField}
                            onChange={handleProdDateChange}
                            InputLabelProps={{
                                shrink: true,
                            }}
                        />
                        <TextField
                            id="expDate"
                            label="Expiration Date"
                            type="date"
                            className={classes.textField}
                            onChange={handleExpDateChange}
                            InputLabelProps={{
                                shrink: true,
                            }}
                        />
                    </form>
                </DialogContent>
                <DialogActions>
                    <Button onClick={props.close} color="primary">
                        Cancel
          </Button>
                    <Button onClick={props.close} color="primary" autoFocus>
                        Confirm
          </Button>
                </DialogActions>
            </Dialog>
        </div>
    );
}