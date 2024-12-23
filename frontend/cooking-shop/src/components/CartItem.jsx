import {
  Text,
  Button,
  Card,
  CardHeader,
  Heading,
  Divider,
  CardBody,
} from "@chakra-ui/react";

export default function CartItem({ item, onRemove }) {
  const onCartbuttonClick = () => {
    onRemove(item.id);
  };
  return (
    <Card variant={"filled"} backgroundColor={"teal.300"}>
      <CardHeader>
        <Heading size={"md"}>Название: {item.name}</Heading>
      </CardHeader>
      <Divider borderColor={"black"}></Divider>
      <CardBody>
        <Text fontSize={"md"}>Описание: {item.description}</Text>
        <Text fontSize={"md"}>Количество: {item.quantity}</Text>
        <Text fontSize={"xl"}>Цена: {item.price} деревянных</Text>
      </CardBody>
      <Button onClick={onCartbuttonClick} backgroundColor={"pink.200"}>
        Удалить
      </Button>
    </Card>
  );
}
