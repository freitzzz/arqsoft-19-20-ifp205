import { createMeal } from '../../../Model/Meal';
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
import EditIcon from '@material-ui/icons/Edit';
import TextField from '@material-ui/core/TextField';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogContentText from '@material-ui/core/DialogContentText';
import DialogTitle from '@material-ui/core/DialogTitle';
import { Chip, Select, FormControl, MenuItem } from '@material-ui/core';
//Merely for demo
const rows = [
  createMeal(0, 'Sopa de Pedra', 'Sopa', 'Água, Pedra', 'Alho', '100 kcal'),
  createMeal(1, 'Arroz de frango', 'Dish', 'Arroz, Frango', 'Alho', '450 kcal'),
  createMeal(2, 'Sopa de Pedra', 'Sopa', 'Água, Pedra', 'Alho', '100 kcal'),
  createMeal(3, 'Sopa de Pedra', 'Sopa', 'Água, Pedra', 'Alho', '100 kcal'),
  createMeal(4, 'Sopa de Pedra', 'Sopa', 'Água, Pedra', 'Alho', '100 kcal'),
  createMeal(5, 'Sopa de Pedra', 'Sopa', 'Água, Pedra', 'Alho', '100 kcal'),
];

const useStyles = makeStyles(theme => ({
  button: {
    margin: theme.spacing(1),
  },
}));

export default function MealList() {
  const classes = useStyles();

  const [meals, setMeals] = useState([]);
  const header = ['Designation', 'Meal Type', 'Ingredients', 'Allergens', 'Descriptors', 'Actions']
    .map((title) => { return (<TableCell>{title}</TableCell>) });

  const [open, setOpen] = React.useState(false);
  const handleCreateMealDialog = () => {
    setOpen(!open);
  }

  const [ingredients, setIngredients] = useState([]);

  const handleCreateIngredient = (event) => {
    if (event.key === 'Enter') {
      setIngredients([...ingredients, event.target.value]);
      event.target.value = '';
    }
  }

  const handleRemoveIngredient = ingredient => () => {
    setIngredients(ingredients => ingredients.filter(ingredientItem => ingredientItem !== ingredient));
  }

  const [mealType, setMealType] = useState('');

  const handleCreateMealType = (event) => {
    if (event.key === 'Enter') {
      setMealType(event.target.value);
    }
  }

  const [allergens, setAllergens] = useState([]);

  const handleCreateAllergen = (event) => {
    if (event.key === 'Enter') {
      setAllergens([...allergens, event.target.value]);
      event.target.value = '';
    }
  }

  const handleRemoveAllergen = allergen => () => {
    setAllergens(allergens => allergens.filter(allergenItem => allergenItem !== allergen));
  }

  const [descriptors, setDescriptors] = useState([]);
  const [quantity, setQuantity] = useState();
  const [quantityUnit, setQuantityUnit] = useState();
  const [name, setName] = useState([]);

  const handleCreateDescriptor = () => {
    setDescriptors([...descriptors, { quantity: quantity, quantityUnit: quantityUnit, name: name }]);
  }

  const handleRemoveDescriptor = descriptor => () => {
    setDescriptors(descriptors => descriptors.filter(descriptorItem => descriptorItem !== descriptor));
  }

  const handleCreateQuantity = (event) => {
    setQuantity(event.target.value);
  }

  const handleCreateQuantityUnit = (event) => {
    setQuantityUnit(event.target.value);
  }

  const handleCreateName = (event) => {
    setName(event.target.value);
  }

  useEffect(() => {
    //TODO: Retrieve Meals from the API
    /*Example: var req = fetch(api_url/meals);
    var reqObj = JSON.parse(req);
    for(reqObj.Meal in reqObj){
     setMeals(meals + {reqObj.description, ...})
    }
    */
    setMeals(rows);
  }, []);

  const ingredientChips = ingredients.map(ingredient => { return <Chip label={ingredient} onDelete={handleRemoveIngredient(ingredient)} /> })
  const allergenChips = allergens.map(allergen => { return <Chip label={allergen} onDelete={handleRemoveAllergen(allergen)} /> })
  // const descriptorChips = descriptors.map(descriptor => { return <Chip label={`${descriptor.quantity} ${descriptor.quantityUnit} ${}`} onDelete={handleRemoveDescriptor(descriptor)} /> })

  const units = ['kg', 'g', 'mg', 'kcal']
    .map((unit) => { return (<MenuItem value={unit}>{unit}</MenuItem>) });

  const names = ['Rice', 'Pasta', 'Garlic']
    .map((name) => { return (<MenuItem value={name}>{name}</MenuItem>) });

  return (
    <React.Fragment>
      <Title>Meals</Title>
      <Table size="small">
        <TableHead>
          <TableRow>
            {header}
          </TableRow>
        </TableHead>
        <TableBody>
          {meals.map(row => (
            <TableRow key={row.id}>
              <TableCell>{row.designation}</TableCell>
              <TableCell>{row.mealType}</TableCell>
              <TableCell>{row.ingredients}</TableCell>
              <TableCell>{row.allergens}</TableCell>
              <TableCell>{row.descriptors}</TableCell>
              <TableCell align="center">
                <IconButton aria-label="edit" className={classes.margin}>
                  <EditIcon fontSize="small" />
                </IconButton>
              </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
      <div>
        <Button variant="contained" size="small" color="primary" className={classes.button} onClick={handleCreateMealDialog}>
          Create Meal
    </Button>
      </div>
      <Dialog open={open} aria-labelledby="form-dialog-title">
        <DialogTitle id="form-dialog-title">Create Meal</DialogTitle>
        <DialogContent>
          <DialogContentText>
            Create a new Meal
        </DialogContentText>
          <div>
            <TextField autoFocus margin="dense" id="name" label="Designation" fullWidth />
            <TextField autoFocus margin="dense" id="meal_type" label="Meal Type" onKeyPressCapture={handleCreateMealType} />
            <div>
              <FormControl>
                <Select autoFocus margin="dense" id="ingredients" label="Ingredients" onKeyPressCapture={handleCreateIngredient} >
                  {names}
                </Select>
              </FormControl>
              {ingredientChips}
            </div>
            <div>
              <TextField autoFocus margin="dense" id="allergens" label="Allergens" onKeyPressCapture={handleCreateAllergen} />
              {allergenChips}
            </div>
            <div>
              <TextField autoFocus margin="dense" id="quantity" label="Quantity" onChange={handleCreateAllergen} />
              <FormControl variant="outlined">
                <Select autoFocus margin="dense" id="quantity_unit" label="Quantity Unit" onChange={handleCreateQuantityUnit} >
                  {units}
                </Select>
                <Select autoFocus margin="dense" id="name" label="Name" onChange={handleCreateName} />
                <Button onClick={handleCreateDescriptor} color="primary">Add Descriptor</Button>
              </FormControl>
              {/* {descriptorChips} */}
            </div>
          </div>
        </DialogContent>
        <DialogActions>
          <Button onClick={handleCreateMealDialog} color="primary">
            Cancel
            </Button>
          <Button onClick={handleCreateMealDialog} color="primary">
            Submit
            </Button>
        </DialogActions>
      </Dialog>
    </React.Fragment>
  );
}
