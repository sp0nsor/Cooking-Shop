import {
  Text,
  Button,
  Card,
  CardHeader,
  Heading,
  Divider,
  CardBody,
  Stack,
} from "@chakra-ui/react";

export default function Recipe({ recipe }) {
  return (
    <Card variant={"filled"} backgroundColor={"blue.200"}>
      <CardHeader>
        <Heading size={"md"}>Название: {recipe.name}</Heading>
      </CardHeader>
      <Divider borderColor={"black"} />
      <CardBody>
        <Text fontSize={"lg"}>Ингредиенты:</Text>
        <Stack spacing={2}>
          {recipe.ingredients.map((ingredient, index) => (
            <Text key={index}>
              {ingredient.name} - {ingredient.unit}
            </Text>
          ))}
        </Stack>
      </CardBody>
    </Card>
  );
}
