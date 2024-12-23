import {
  Text,
  Button,
  Card,
  CardHeader,
  Heading,
  Divider,
  CardBody,
} from "@chakra-ui/react";

export default function Food({ food, onSubmit }) {
  const onCartbuttonClick = () => {
    onSubmit(food);
  };
  return (
    <Card variant={"filled"} backgroundColor={"blue.200"}>
      <CardHeader>
        <Heading size={"md"}>Название: {food.name}</Heading>
      </CardHeader>
      <Divider borderColor={"black"}></Divider>
      <CardBody>
        <Text fontSize={"md"}>Описание: {food.description}</Text>
        <Text fontSize={"xl"}>Цена: {food.price} деревянных</Text>
      </CardBody>
      <Button onClick={onCartbuttonClick} backgroundColor={"pink.200"}>
        Добавить в корзину
      </Button>
    </Card>
  );
}
