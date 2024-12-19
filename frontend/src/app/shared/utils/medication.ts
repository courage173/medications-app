export function mapEditData(input: any) {
  return {
    name: input.name,
    competentAuthorityStatus: {
      name: input.competentAuthorityStatus,
      code: input.competentAuthorityStatus,
    },
    internalStatus: {
      name: input.internalStatus,
      code: input.internalStatus,
    },
    unit: input.unit,
    pharmaceuticalFormName: {
      id: input.pharmaceuticalFormId,
      name: input.pharmaceuticalFormName,
    },
    atcCodeName: {
      id: input.atcCodeId,
      name: input.atcCodeName,
      code: input.atcCodeName,
    },
    therapeuticClassName: {
      id: input.therapeuticClassId,
      name: input.therapeuticClassName,
    },
    classificationName: {
      name: input.classificationName,
      code: input.classificationName,
    },
    activeIngredients: input.activeIngredients.map((ingredient: any) => ({
      name: ingredient.name,
      id: ingredient.id,
      dosage: ingredient.dosage,
    })),
  };
}

export function mapDataToSubmit(input: any): any {
  return {
    name: input.name,
    competentAuthorityStatus: input.competentAuthorityStatus.name,
    internalStatus: input.internalStatus.name,
    unit: input.unit,
    pharmaceuticalFormId: input.pharmaceuticalFormName.id,
    atcCodeId: input.atcCodeName.id,
    therapeuticClassId: input.therapeuticClassName.id,
    classification: input.classificationName.name,
    activeIngredients: input.activeIngredients.map((ingredient: any) => ({
      activeIngredientId: ingredient.id,
      dosage: ingredient.dosage,
    })),
  };
}
