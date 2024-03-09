from flask import Flask, request, jsonify
import spacy

nlp = spacy.load("hu_core_news_lg")
app = Flask(__name__)

@app.route("/")
def hello_world():
    return "<p>Hello, World!</p>"

@app.route("/analyzeSingle", methods=['POST'])
def analyzeSingleCorpus():
    data = request.get_json()
    if 'corpus' not in data:
        return jsonify({"error": "Missing 'corpus' key in JSON data"}), 400
    text=data['corpus']
    return jsonify(getNamedEntities(text))


@app.route("/analyzeBatch", methods=['POST'])
def analyzeBatchCorpus():
    data = request.get_json()
    if 'corpus' not in data:
        return jsonify({"error": "Missing 'corpus' key in JSON data"}), 400
    text=data['corpus']
    return jsonify(getNamedEntities(text))



def getNamedEntities(text:str):
    doc = nlp(text)
    
    named_entities = {}
    entity_mapping = {}  # Dictionary to map different entity mentions to a canonical representation

    for ent in doc.ents:
        canonical_entity = entity_mapping.get(ent.text, ent)  # Get the canonical representation or use the entity itself

        # Update entity mapping to link all text variations to the same canonical representation
        for alias in ent:
            entity_mapping[alias.text] = canonical_entity

        if canonical_entity.label_ not in named_entities:
            named_entities[canonical_entity.label_] = set()

        named_entities[canonical_entity.label_].add(canonical_entity.lemma_)
    
    return {key: list(value) for key, value in named_entities.items()}

if __name__=="__main__":
    app.run(host="0.0.0.0", debug=True)

    #print(f"{source} Processed result: {result}")