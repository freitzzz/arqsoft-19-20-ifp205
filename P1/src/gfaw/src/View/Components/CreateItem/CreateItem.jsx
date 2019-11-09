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
import { getData } from '../../../Controller/GetController';
import { createMeal } from '../../../Model/Meal';
import { postData } from '../../../Controller/PostController';

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

    //All meals found in the database
    const [meals, setMeals] = React.useState([]);

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
    };

    //Expiration Date state
    const [selectedExpDate, setSelectedExpDate] = React.useState();

    const handleExpDateChange = event => {
        setSelectedExpDate(event.target.value);
    };

    const handleNewItemCreation = event => {
        var itemData = { mealId: baseMeal, location: selectedLocation, productionDate: selectedProdDate, expirationDate: selectedExpDate }


        console.log(JSON.stringify(itemData));
        postData('items', JSON.stringify(itemData));
    };

    useEffect(() => {
        var meals = getData('meals');
        var rows = [];
        meals.then((data) => {
            for (var i = 0; i < data.length; i++) {
                var meal = data[i];
                var newMeal = createMeal(meal.id, meal.designation, meal.mealType, 0, 0, 0);
                rows.push(newMeal);
            }
        }).then(() => { setMeals(rows); })
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
                            {meals.map(row => (
                                <MenuItem value={row.id}>{row.designation}</MenuItem>
                            ))}
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
                    <Button onClick={() => { handleNewItemCreation(); props.close(); }} color="primary" autoFocus>
                        Submit
          </Button>
                </DialogActions>
            </Dialog>
        </div>
    );
}